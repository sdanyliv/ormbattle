// Copyright (C) 2003-2010 Xtensive LLC.
// All rights reserved.
// For conditions of distribution and use, see license.
// Created by: Alex Yakunin
// Created:    2010.05.17

using System;
using System.Collections.Generic;
using System.Diagnostics;
using NDesk.Options;
using Xtensive.Core;
using System.Linq;

namespace ProjectUpgrader.Logic
{
  [Serializable]
  public sealed class UpgradeConfiguration
  {
    private readonly static Dictionary<Language, string> ProjectExtensions = new Dictionary<Language, string>() {
      { Language.CSharp, ".csproj" },
      { Language.VisualBasic, ".vbproj" },
      { Language.FSharp, ".fsproj" },
    };

    private string solutionPath;
    private string sourcePath;

    public string SolutionPath {
      get { return solutionPath; }
      set {
        if (value.IsNullOrEmpty())
          throw new ArgumentException("Solution name must not be an empty string.", "value");
        string lowerCaseValue = value.ToLower();
        if (!lowerCaseValue.EndsWith(".sln"))
          throw new ArgumentException("Solution name must end with .sln.", "value");
        solutionPath = value;
      }
    }

    public string SourcePath {
      get { return sourcePath; }
      set {
        if (value.IsNullOrEmpty())
          throw new ArgumentException("Project name must not be an empty string.", "value");
        string lowerCaseValue = value.ToLower();
        if (!ProjectExtensions.Values.Any(extension => lowerCaseValue.EndsWith(extension)))
          throw new ArgumentException("Project name must end with {0}.".FormatWith(ProjectExtensions.Values.ToCommaDelimitedString()), "value");
        sourcePath = value;
      }
    }

    public Language SourceLanguage { 
      get
      {
        return (
          from p in ProjectExtensions
          where sourcePath.EndsWith(p.Value)
          select p.Key
          ).SingleOrDefault();
      }
    }

    public UpgradeOptions Options { get; set; }

    public void UpdateByCommandLine()
    {
      var help = false;
      var parser = new OptionSet () {
   	    { "r|addReferences", "Add references to DataObjects.Net assemblies",
          o => Options.AddReferences = o!=null },
   	    { "i|addImports", "Add references to DataObjects.Net .target files",
          o => Options.AddImports = o!=null },
   	    { "d|copyIndirectDependencies", "Project requires all indirectly referenced assemblies to be copied to Bin folder",
          o => Options.CopyIndirectDependencies = o!=null },
   	    { "s|skipPostSharp", "Project does not require PostSharp",
          o => Options.SkipPostSharp = o!=null },
   	    { "u|upgrade", "Extract option values from DataObjects.Net project file",
          o => Options.ExtractOptions = o!=null },
   	    { "sln:", "Solution file to upgrade (.sln upgrade mode)",
          o => { 
            SolutionPath = o;
            Options.UpgradeSolution = true;
   	      }
        },
   	    { "a|auto",    "Automatic mode: window with options won't be shown",
          o => Options.Auto = o!=null },
   	    { "debug",     "Debug mode: save a copy of each processed file with .processed extension instead of overwriting it",
          o => Options.DebugMode = o!=null },
   	    { "h|?|help",   
          o => help = o!=null },
      };
     
      List<string> extra;
      try {
        extra = parser.Parse (Environment.GetCommandLineArgs());
        if (help)
          ShowHelp(parser);

        if (extra.Count>2)
          throw new ApplicationException("Too many arguments.");
        if (extra.Count==2)
          SourcePath = extra[1];
      }
      catch (Exception e) {
        Console.WriteLine("Error: {0}", e.Message);
        Console.WriteLine("Use '{0} -?' option for more information.", Process.GetCurrentProcess().ProcessName);
        Environment.Exit(1);
      }
    }

    private void ShowHelp(OptionSet parser)
    {
      Console.WriteLine("Usage: {0} [Option]... [Project file]", Process.GetCurrentProcess().ProcessName);
      Console.WriteLine("Enables C#/F#/VB.NET projects to use DataObjects.Net.");
      Console.WriteLine();
      Console.WriteLine("Options:");
      parser.WriteOptionDescriptions (Console.Out);      
      Console.WriteLine("");
      Console.WriteLine("Flag options can be turned on and off:");
      Console.WriteLine("  -Option+ or -Option turns on the option;");
      Console.WriteLine("  -Option- turn it off.");
      Console.WriteLine("");
      Console.WriteLine("Flag option values are determined by the following");
      Console.WriteLine("sequence of applied rules:");
      Console.WriteLine("  1. Values read from project file (if -u is specified);");
      Console.WriteLine("  2. Values provided as command line arguments;");
      Console.WriteLine("  3. Values provided in UI (if there is no -a).");
      Console.WriteLine("");
      Console.WriteLine("If solution file is specified, all of its projects");
      Console.WriteLine("are upgraded using the options extracted from them.");
      Environment.Exit(0);
    }

    
    // Constructors
    
    public UpgradeConfiguration()
    {
      Options = new UpgradeOptions();
    }
  }
}