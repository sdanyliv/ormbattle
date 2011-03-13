// Copyright (C) 2003-2010 Xtensive LLC.
// All rights reserved.
// For conditions of distribution and use, see license.
// Created by: Alex Yakunin
// Created:    2010.05.19

using System;

namespace ProjectUpgrader.Logic
{
  [Serializable]
  public sealed class UpgradeOptions
  {
    public bool AddImports { get; set; }
    public bool AddReferences { get; set; }
    public bool CopyIndirectDependencies { get; set; }
    public bool SkipPostSharp { get; set; }
    public bool ExtractOptions { get; set; }
    public bool UpgradeSolution { get; set; }
    public bool UpgradeProject { get; set; }
    public bool Auto { get; set; }
    public bool DebugMode { get; set; }

    // Purely UI-related stuff
    public int UITabIndex {
      get { return UpgradeSolution ? 0 : 1; }
      set { UpgradeSolution = value==0; }
    }
  }
}
