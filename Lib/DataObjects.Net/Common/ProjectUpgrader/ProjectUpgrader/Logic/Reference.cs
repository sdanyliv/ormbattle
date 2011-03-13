// Copyright (C) 2003-2010 Xtensive LLC.
// All rights reserved.
// For conditions of distribution and use, see license.
// Created by: Alex Yakunin
// Created:    2010.05.19

using System;

namespace ProjectUpgrader.Logic
{
  [Serializable]
  public sealed class Reference
  {
    public string Name { get; set; }
    public bool? SpecificVersion { get; set; }
    public string RequiredTargetFramework { get; set; }
    public bool RemoveHintPath { get; set; }

    public string BaseName {
      get {
        int commaIndex = Name.IndexOf(',');
        return (commaIndex < 0) ? Name : Name.Substring(0, commaIndex);
      }
    }

    public string DllName {
      get { return BaseName + ".dll"; }
    }

    // Constructors

    public Reference(string name, bool removeHintPath = false, bool? specificVersion = null, string requiredTargetFramework = null)
    {
      Name = name;
      SpecificVersion = specificVersion;
      RequiredTargetFramework = requiredTargetFramework;
      RemoveHintPath = removeHintPath;
    }
  }
}