// Copyright (C) 2003-2010 Xtensive LLC.
// All rights reserved.
// For conditions of distribution and use, see license.
// Created by: Alex Yakunin
// Created:    2010.05.19

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Linq;
using ProjectUpgrader.Logic.Xslt;
using Xtensive.Core;
using System.Xml.XPath;

namespace ProjectUpgrader.Logic
{
  public sealed class Upgrader
  {
    public static readonly string DataObjectsDotNetPath = "DataObjectsDotNetPath";
    public static readonly string BinLatestPath = @"{0}\Bin\Latest";
    public static readonly string ProcessedSuffix = ".processed";
    public static readonly string PreviousAssemblyVersion = "1.0.0.0";
    public static readonly string CurrentAssemblyVersion = "4.4.0.0";

    public static readonly string DefaultNamespace = "http://schemas.microsoft.com/developer/msbuild/2003";
    public static readonly string[] LanguageTargets = new string[] {
      "Microsoft.CSharp.targets",
      "Microsoft.FSharp.targets",
      "Microsoft.VisualBasic.targets"
    };
    public static readonly string XtensiveReferenceSuffix =
      ", Version={0}, Culture=neutral, PublicKeyToken=93a6c53d77a5296c, processorArchitecture=MSIL".FormatWith(CurrentAssemblyVersion);
    public static readonly ReferenceList References = new ReferenceList {
      { "PostSharp, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b13fd38b8f9c99d7, processorArchitecture=MSIL", true, true },
      { "WindowsBase", true, null, null },
      { "Xtensive.Core" + XtensiveReferenceSuffix, true, true },
      { "Xtensive.Aspects" + XtensiveReferenceSuffix, true, true },
      { "Xtensive.Orm" + XtensiveReferenceSuffix, true, true },
    };
    public static readonly string[] ReferencesToCleanup = new string[] {
      "Xtensive.Core.Aspects",
      "Xtensive.Integrity",
      "Xtensive.Modelling",
      "Xtensive.Sql",
      "Xtensive.Sql.All",
      "Xtensive.Storage.All",
      "Xtensive.Storage.Model",
      "Xtensive.Storage.Rse",
    };
    public static readonly Pair<string>[] ReferencesToReplace = new Pair<string>[] {
      new Pair<string>("Xtensive.Storage", "Xtensive.Orm"),
    };
    public static readonly Pair<string>[] NamespaceReplacements = new Pair<string>[] {
      new Pair<string>(@"Core\.(?<ns>[\w\.\*]+)", @"${ns}"), 
      new Pair<string>(@"Integrity", null), 
      new Pair<string>(@"Integrity\.Validation", @"Orm.Validation"), 
      new Pair<string>(@"Integrity\.Aspects", @"Orm.Validation"), 
      new Pair<string>(@"Integrity\.Aspects\.Constraints", @"Orm.Validation"), 
      new Pair<string>(@"Storage", @"Orm"), 
      new Pair<string>(@"Storage\.(?<ns>(?!(Providers|Rse|Indexing|Web))[\w\.\*]+)", @"Orm.${ns}"), 
      new Pair<string>(@"Storage\.Indexing", @"Storage.Commands"), 
      new Pair<string>(@"Storage\.Indexing\.Model", @"Storage.Model"), 
      new Pair<string>(@"Storage\.Web", @"Practices.Web"), 
    };


    public UpgradeConfiguration Configuration { get; set; }
    public XDocument Project { get; private set; }
    public string Solution { get; private set; }

    public void Process()
    {
      if (Configuration.Options.UpgradeSolution)
        ProcessSolution();
      else
        ProcessProject();
    }

    public void ExtractOptions()
    {
      if (Project==null)
        Project = LoadProject();
      var cfg = Configuration;

      var resolver = CreateResolver();
      string pfx = "/Project";

      Console.WriteLine("  Extracting options from project file...");

      // Detecting upgrade
      if (Project.XPathSelectElements(pfx + "/ItemGroup/Reference[starts-with(@e:Include,'Xtensive.Storage,')]", resolver).Any())
        cfg.Options.UpgradeProject = true;
      else if (Project.XPathSelectElements(pfx + "/ItemGroup/Reference[starts-with(@e:Include,'Xtensive.Core.Aspects,')]", resolver).Any())
        cfg.Options.UpgradeProject = true;
      if (Project.XPathSelectElements(pfx + "/ItemGroup/Reference[starts-with(@e:Include,'Xtensive.Core, Version=1.0.0.0')]", resolver).Any())
        cfg.Options.UpgradeProject = true;

      // Detecting references
      if (Project.XPathSelectElements(pfx + "/ItemGroup/Reference[starts-with(@e:Include,'Xtensive.Orm,')]", resolver).Any())
        cfg.Options.AddReferences = true;
      if (Project.XPathSelectElements(pfx + "/ItemGroup/Reference[starts-with(@e:Include,'Xtensive.Storage,')]", resolver).Any())
        cfg.Options.AddReferences = true;

      // Detecting imports
      if (Project.XPathSelectElements(pfx + "/Import[ends-with(@e:Project,'DataObjects.Net.targets')]", resolver).Any())
        cfg.Options.AddImports = true;

      // Detecting SkipPostSharp and CopyIndirectDependencies
      bool? skipPostSharp = null;
      bool? copyIndirectDependencies = null;
      if (Project.XPathSelectElements(pfx + "/PropertyGroup[SkipPostSharp = 'true']", resolver).Any())
        skipPostSharp = true;
      if (Project.XPathSelectElements(pfx + "/PropertyGroup[SkipPostSharp = 'false']", resolver).Any())
        skipPostSharp = false;
      if (Project.XPathSelectElements(pfx + "/PropertyGroup[CopyIndirectDependencies = 'true']", resolver).Any())
        copyIndirectDependencies = true;
      if (Project.XPathSelectElements(pfx + "/PropertyGroup[CopyIndirectDependencies = 'false']", resolver).Any())
        copyIndirectDependencies = false;
      if (Project.XPathSelectElements(pfx + "/Import[ends-with(@e:Project,'Defaults.DllProject.targets')]", resolver).Any()) {
        skipPostSharp = true;
        copyIndirectDependencies = false;
      }
      if (Project.XPathSelectElements(pfx + "/Import[ends-with(@e:Project,'Defaults.ExeProject.targets')]", resolver).Any()) {
        skipPostSharp = true;
        copyIndirectDependencies = true;
      }
      if (Project.XPathSelectElements(pfx + "/Import[ends-with(@e:Project,'Defaults.TestsProject.targets')]", resolver).Any()) {
        skipPostSharp = true;
        copyIndirectDependencies = true;
      }
      if (Project.XPathSelectElements(pfx + "/Import[ends-with(@e:Project,'Defaults.ModelProject.targets')]", resolver).Any()) {
        skipPostSharp = false;
        copyIndirectDependencies = false;
      }
      if (Project.XPathSelectElements(pfx + "/Import[ends-with(@e:Project,'Defaults.MixedProject.targets')]", resolver).Any()) {
        skipPostSharp = false;
        copyIndirectDependencies = true;
      }
      if (skipPostSharp.HasValue)
        cfg.Options.SkipPostSharp = skipPostSharp.Value;
      if (copyIndirectDependencies.HasValue)
        cfg.Options.CopyIndirectDependencies = copyIndirectDependencies.Value;

      Console.WriteLine("  Done.");
    }

    private void ProcessSolution()
    {
      if (Solution==null)
        Solution = LoadSolution();

      Console.WriteLine("  Processing solution file...");

      try {
        string versionString = Regex.Match(Solution, 
          @"^\s+Microsoft Visual Studio Solution File, Format Version (\d+\.\d+)\s*").Groups[1].Value;
        var version = Version.Parse(versionString);
        Console.WriteLine("    File format version: {0}", version);
        if (version.Major<10.0 || version.Major>11.0)
          throw new ApplicationException(
            "Version {0} of solution file format is not supported.".FormatWith(versionString));
      }
      catch (ApplicationException) {
        throw;
      }
      catch (Exception) {
        throw new ApplicationException("Invalid solution file format.");
      }

      var projects = new List<string>();
      try {
        var projectRegex = new Regex(@"^Project.+\s*=\s*""([^""]+)""\s*,\s*""([^""]+)""\s*,\s*""[^""]+""\s*", RegexOptions.Multiline);
        var match = projectRegex.Match(Solution);
        while (match.Success) {
          string projectName = match.Groups[1].Value;
          string projectFile = match.Groups[2].Value;
          if (projectName==projectFile) {
            Console.WriteLine("    Solution folder found: '{0}' - skipped", projectName);
          }
          else {
            Console.WriteLine("    Project found: '{0}'", projectName);
            Console.WriteLine("      Path: {0}", projectFile);
            projects.Add(projectFile);
          }
          match = match.NextMatch();
        }
      }
      catch (Exception) {
        throw new ApplicationException("Invalid solution file format.");
      }

      Console.WriteLine("  Done, total # of projects to upgrade: {0}.", projects.Count);

      // Upgrading projects

      var solutionDir = Path.GetDirectoryName(Configuration.SolutionPath);
      foreach (var project in projects) {
        try {
          var cfg = new UpgradeConfiguration();
          cfg.SourcePath = Path.Combine(solutionDir, project);
          cfg.Options.ExtractOptions = true;
          cfg.Options.DebugMode = Configuration.Options.DebugMode;
          var upgrader = new Upgrader(cfg);
          upgrader.ExtractOptions();
          upgrader.Process();
        }
        catch (Exception error) {
          ErrorReporter.Report(error);
        }
      }
    }

    private void ProcessProject()
    {
      if (Project==null)
        Project = LoadProject();
      var cfg = Configuration;

      var resolver = CreateResolver();
      string pfx = "/Project";

      Console.WriteLine("  Processing project file...");

      // Cleanup
      Project.XPathSelectElements(pfx + "/PropertyGroup/SkipPostSharp", resolver)
        .ToList().ForEach(e => e.Remove());
      Project.XPathSelectElements(pfx + "/PropertyGroup/CopyIndirectDependencies", resolver)
        .ToList().ForEach(e => e.Remove());
      Project.XPathSelectElements(pfx + "/PropertyGroup/DontImportPostSharp", resolver)
        .ToList().ForEach(e => e.Remove());
      Project.XPathSelectElements(pfx + "/Import[ends-with(@e:Project,'DataObjects.Net.targets')]", resolver)
        .ToList().ForEach(e => e.Remove());
      if (cfg.Options.UpgradeProject) {
        foreach (var pair in ReferencesToReplace) {
          Project.XPathSelectElements(pfx + "/ItemGroup/Reference[starts-with(@e:Include,'{0},')]".FormatWith(pair.First), resolver)
            .ToList().ForEach(e => e.Attribute("Include").Value = pair.Second + XtensiveReferenceSuffix);
        }
      }
      if (cfg.Options.AddImports) {
        Project.XPathSelectElements(pfx + "/ItemGroup/Reference[starts-with(@e:Include,'Xtensive.Orm,')]/HintPath", resolver)
          .ToList().ForEach(e => e.Remove());
      }
      var targets = (
        from baseName in new[] {"Dll", "Exe", "Web", "Model", "Mixed"}
        select "Defaults.{0}Project.targets".FormatWith(baseName)
        ).ToArray();
      foreach (var target in targets)
        Project.XPathSelectElements(pfx + "/Import[ends-with(@e:Project,'{0}')]".FormatWith(target), resolver)
          .ToList().ForEach(e => e.Remove());
      foreach (var reference in ReferencesToCleanup)
        Project.XPathSelectElements(pfx + "/ItemGroup/Reference[starts-with(@e:Include,'{0}, ') or @e:Include='{0}']".FormatWith(reference), resolver)
          .ToList().ForEach(e => e.Remove());

      // Processing
      var languageImport = (
        from target in LanguageTargets
        from element in Project.XPathSelectElements(pfx + "/Import[ends-with(@e:Project,'{0}')]".FormatWith(target), resolver)
        select element).SingleOrDefault();
      if (languageImport==null)
        throw new ApplicationException("Unsupported project type.");
      var lastGlobalProperty =
        Project.XPathSelectElements(pfx + "/PropertyGroup[position()=1]/*[last()]", resolver).Single();
      var lastReferenceItem =
        Project.XPathSelectElements(pfx + "/ItemGroup/Reference[last()]", resolver).Single();

      if (cfg.Options.AddReferences || cfg.Options.UpgradeProject) {
        foreach (var reference in References) {
          var existingReferences =
            Project.XPathSelectElements(pfx + "/ItemGroup/Reference[starts-with(@e:Include,'{0}, ') or @e:Include='{0}']".FormatWith(reference.BaseName), resolver).ToArray();
          if (existingReferences.Length > 1) {
            Console.WriteLine("Multiple references to '{0}' are found, skipping:", reference.BaseName);
            foreach (var existingReference in existingReferences)
              Console.WriteLine("  {0}", existingReference.Attribute("Include").Value);
            continue;
          }

          if (existingReferences.Length==0) {
            if (!cfg.Options.AddReferences)
              continue; // We don't add new references on project upgrade
            var newReference =
              new XElement(XName.Get("Reference", DefaultNamespace),
                new XAttribute("Include", reference.Name));
            lastReferenceItem.AddAfterSelf(newReference);
            existingReferences = new XElement[] {newReference};
          }
          var referenceElement = existingReferences[0];

          // Updating new or created reference
          var includeAttribute = referenceElement.Attribute("Include");
          if (includeAttribute!=null && includeAttribute.Value!=reference.Name.Trim()) {
            includeAttribute.Value = reference.Name;
          }

          if (reference.RemoveHintPath) {
            referenceElement.Descendants(XName.Get("HintPath", DefaultNamespace))
              .ToList().ForEach(e => e.Remove());
          }
          else {
            string dataObjectsDotNetPath = Environment.GetEnvironmentVariable(DataObjectsDotNetPath);
            string hintPathBase = BinLatestPath.FormatWith(dataObjectsDotNetPath);
            var hintPath = referenceElement.Descendants(XName.Get("HintPath", DefaultNamespace)).SingleOrDefault();
            if (hintPath==null) {
              hintPath = new XElement(XName.Get("HintPath", DefaultNamespace));
              referenceElement.Add(hintPath);
            }
            hintPath.Value = Path.Combine(hintPathBase, reference.DllName.Trim());
          }
          if (reference.SpecificVersion.HasValue) {
            referenceElement.Descendants(XName.Get("SpecificVersion", DefaultNamespace))
              .ToList().ForEach(e => e.Remove());
            referenceElement.AddFirst(
              new XElement(XName.Get("SpecificVersion", DefaultNamespace),
                reference.SpecificVersion.Value.ToString()));
          }
          if (!reference.RequiredTargetFramework.IsNullOrEmpty()) {
            referenceElement.Descendants(XName.Get("RequiredTargetFramework", DefaultNamespace))
              .ToList().ForEach(e => e.Remove());
            referenceElement.AddFirst(
              new XElement(XName.Get("RequiredTargetFramework", DefaultNamespace),
                reference.RequiredTargetFramework));
          }
        }
      }

      if (cfg.Options.AddImports) {
        languageImport.AddAfterSelf(
          new XElement(XName.Get("Import", DefaultNamespace),
            new XAttribute("Project", @"$(DataObjectsDotNetPath)\Common\DataObjects.Net.targets")));

        if (cfg.Options.SkipPostSharp)
          lastGlobalProperty.AddAfterSelf(
            new XElement(XName.Get("SkipPostSharp", DefaultNamespace), "true"));

        if (cfg.Options.CopyIndirectDependencies)
          lastGlobalProperty.AddAfterSelf(
            new XElement(XName.Get("CopyIndirectDependencies", DefaultNamespace), "true"));
      }

      if (cfg.Options.UpgradeProject) {
        // Upgrading AssemblyInfo.cs files
        var assemblyInfos =
          from e in Project.XPathSelectElements(pfx + "/ItemGroup/Compile[@e:Include='AssemblyInfo.cs' or ends-with(@e:Include,'\\AssemblyInfo.cs')]", resolver)
          let a = e.Attribute("Include")
          select a==null ? null : a.Value;
        // Unnecessary in v4.4
        // ProcessFiles(assemblyInfos, "AssemblyInfo file", ProcessAssemblyInfo);

        // Upgrading namespaces in .config files
        var configFiles =
          from e in Project.XPathSelectElements(pfx + "/ItemGroup/Content[ends-with(@e:Include,'.config')]", resolver)
          let a = e.Attribute("Include")
          select a==null ? null : a.Value;
        ProcessFiles(configFiles, ".config file", ProcessConfigFile);

        // Upgrading "using" directives in .cs files
        var csFiles =
          from e in Project.XPathSelectElements(pfx + "/ItemGroup/Compile[ends-with(@e:Include,'.cs')]", resolver)
          let a = e.Attribute("Include")
          select a==null ? null : a.Value;
        ProcessFiles(csFiles, "C# file", ProcessCSharpFile);

        // Upgrading "Imports" directives in .vb files
        var vbFiles =
          from e in Project.XPathSelectElements(pfx + "/ItemGroup/Compile[ends-with(@e:Include,'.vb')]", resolver)
          let a = e.Attribute("Include")
          select a==null ? null : a.Value;
        ProcessFiles(vbFiles, "VB.NET file", ProcessVBFile);

        // Upgrading "<Import>" directives in .aspx/.ascx files
        var aspxFiles =
          from e in Project.XPathSelectElements(pfx + "/ItemGroup/Content[ends-with(@e:Include,'.aspx') or ends-with(@e:Include,'.ascx')]", resolver)
          let a = e.Attribute("Include")
          select a==null ? null : a.Value;
        ProcessFiles(aspxFiles, ".aspx/.ascx file", ProcessAspxFile);
      }

      Console.WriteLine("  Done.");
      SaveProject();
    }

    private void ProcessFiles(IEnumerable<string> files, string description, Func<string, string> processor)
    {
      var cfg = Configuration;
      foreach (var file in files) {
        if (file==null)
          continue;
        try {
          string fileName = Path.Combine(Path.GetDirectoryName(cfg.SourcePath), file);
          string text = LoadFile(fileName, description, "  ", true);
          if (text.IsNullOrEmpty()) {
            Console.WriteLine("    File is empty or does not exist.");
            continue;
          }
          Console.Write("    Processing...");
          try {
            text = processor.Invoke(text);
          }
          catch {
            Console.WriteLine();
            throw;
          }
          Console.WriteLine(" Done.");
          SaveFile(fileName, description, text, "  ");
        } catch (Exception error) {
          ErrorReporter.Report(error);
        }
      }
    }

    private string ProcessAssemblyInfo(string text)
    {
      text = Regex.Replace(text, @"^\s*using Xtensive\.Storage\.Aspects;\s*$", string.Empty, RegexOptions.Multiline);
      text = Regex.Replace(text,@"^\s*\[assembly:\s*(Xtensive\.Storage\.Aspects\.)?Persistent\(.*\)\]\s*$", string.Empty, RegexOptions.Multiline);
      return text;
    }

    private string ProcessConfigFile(string text)
    {
      var options = RegexOptions.Multiline | RegexOptions.IgnoreCase;

      // Replacing section name in section definition
      var replacementText = "${pre}Orm${post}";
      text = Regex.Replace(text, 
        @"^(?<pre>\s*<section\s+name=""Xtensive\.)(?<storage>Storage)\s*(?<post>""\s+type=.*)$",
        replacementText, options);

      // Replacing section name in its usages
      text = Regex.Replace(text, 
        @"^(?<pre>\s*</?Xtensive\.)(?<nameSpace>Storage)(?<post>/?>\s*)$", 
        replacementText, options);

      // Removing assembly versions
      text = Regex.Replace(text,
        @"^(?<pre>\s*<.+""Xtensive\.[^""]+)(?<version>,\s+Version={0},[^""]*\s+PublicKeyToken=93a6c53d77a5296c[^""]*)(?<post>""\s*/>\s*)$"
          .FormatWith(PreviousAssemblyVersion.Replace(".", @"\.")),
        "${pre}${post}", options);

      // Replacing SessionManager reference (won't be properly fixed by the following fixups,
      // since this type is moved to different assembly)
      text = Regex.Replace(text, 
        @"^(?<pre>\s*<add\s+name=""[^""]+""\s+type="")(?<type>Xtensive\.Storage\.Web\.SessionManager,\s+Xtensive\.Storage)(?<post>[^""]*""\s*/>\s*)$", 
        "${pre}Xtensive.Practices.Web.SessionManager, Xtensive.Practices.Web${post}", options);

      // Replacing namespace names in type references
      string importFormat = @"^(?<pre>\s*<.+""Xtensive\.)(?<nameSpace>{0})(?<post>\.[^.,]+,[^""]+""\s*/>\s*)$";
      string replacementFormat = @"${pre}|${post}";
      text = ReplaceNamespaceImports(text, importFormat, replacementFormat, options);

      // Replacing assembly names
      importFormat =  @"^(?<pre>\s*<.+""Xtensive\.[^,]+,\s+Xtensive\.)(?<assembly>{0})(?<post>,[^""]+""\s*/>\s*)$";
      text = ReplaceNamespaceImports(text, importFormat, replacementFormat, options);

      return text;
    }

    private string ProcessCSharpFile(string text)
    {
      string importFormat = @"^(?<pre>\s*using\s+([^=\s]+\s*=\s*)?Xtensive\.)(?<nameSpace>{0})(?<post>\s*;\s*)$";
      string replacementFormat = @"${pre}|${post}";
      var options = RegexOptions.Multiline;

      text = ReplaceNamespaceImports(text, importFormat, replacementFormat, options);
      return text;
    }

    private string ProcessVBFile(string text)
    {
      string importFormat = @"^(?<pre>\s*Imports\s+Xtensive\.)(?<nameSpace>{0})(?<post>\s*)$";
      string replacementFormat = @"${pre}|${post}";
      var options = RegexOptions.Multiline | RegexOptions.IgnoreCase;

      text = ReplaceNamespaceImports(text, importFormat, replacementFormat, options);
      return text;
    }

    private string ProcessAspxFile(string text)
    {
      string importFormat = @"^(?<pre>\s*<%@\s+Import\s+namespace=""\s*Xtensive\.)(?<nameSpace>{0})\s*(?<post>""\s*%>\s*)$";
      string replacementFormat = @"${pre}|${post}";
      var options = RegexOptions.Multiline | RegexOptions.IgnoreCase;

      text = ReplaceNamespaceImports(text, importFormat, replacementFormat, options);
      return text;
    }

    private string ReplaceNamespaceImports(string text, string importFormat, string replacementFormat, RegexOptions options)
    {
      foreach (var pair in NamespaceReplacements) {
        text = Regex.Replace(text, 
          importFormat.FormatWith(pair.First), 
          pair.Second==null 
            ? "\r" 
            : replacementFormat.Replace("|", pair.Second), 
          options);
      }
      return text;
    }

    private string LoadSolution()
    {
      return LoadFile(Configuration.SolutionPath, "solution");
    }

    private XDocument LoadProject()
    {
      string path = Configuration.SourcePath;
      ArgumentValidator.EnsureArgumentNotNull(path, "this.Configuration.SourcePath");
      Console.WriteLine("Loading project: {0}", path);
      using (var stream = File.OpenRead(path))
        return XDocument.Load(stream);
    }

    private string LoadFile(string fileName, string description, string indent = null, bool returnNullIfNone = false)
    {
      ArgumentValidator.EnsureArgumentNotNull(fileName, "fileName");
      ArgumentValidator.EnsureArgumentNotNullOrEmpty(description, "description");
      indent = indent ?? string.Empty;
      Console.WriteLine("{0}Loading {1}: {2}", indent, description, fileName);
      if (returnNullIfNone && !File.Exists(fileName))
        return null;
      return File.ReadAllText(fileName);
    }

    private void SaveProject()
    {
      ArgumentValidator.EnsureArgumentNotNull(Configuration.SourcePath, "this.Configuration.OutputPath");
      string path = Configuration.SourcePath;
      if (Configuration.Options.DebugMode)
        path += ProcessedSuffix;
      Console.WriteLine("Saving project: {0}", path);
      using (var stream = File.OpenWrite(path)) {
        Project.Save(stream);
        stream.SetLength(stream.Position);
      }
    }

    private void SaveFile(string fileName, string description, string text, string indent = null)
    {
      ArgumentValidator.EnsureArgumentNotNull(fileName, "fileName");
      ArgumentValidator.EnsureArgumentNotNullOrEmpty(description, "description");
      ArgumentValidator.EnsureArgumentNotNull(text, "text");
      if (Configuration.Options.DebugMode)
        fileName += ProcessedSuffix;
      indent = indent ?? string.Empty;
      Console.WriteLine("{0}Saving {1}: {2}", indent, description, fileName);
      File.WriteAllText(fileName, text);
    }

    private IXmlNamespaceResolver CreateResolver()
    {
      var namespaceManager = new XmlNamespaceManager(new NameTable());
      namespaceManager.AddNamespace(string.Empty, DefaultNamespace);
      namespaceManager.AddNamespace("m", DefaultNamespace);
      namespaceManager.AddNamespace("e", string.Empty);

      Func<object, string> str = XsltFunction.ArgumentToString;

      return new DefaultXsltContext(namespaceManager, "m", new XsltFunction[] {
        new XsltFunction("ends-with", 
          new [] {XPathResultType.String, XPathResultType.String}, XPathResultType.Boolean,
          (c,d,args) => str(args[0]).EndsWith(str(args[1]))), 
      });
    }


    // Constructors

    public Upgrader(UpgradeConfiguration configuration = null)
    {
      Configuration = configuration ?? new UpgradeConfiguration();
    }
  }
}
