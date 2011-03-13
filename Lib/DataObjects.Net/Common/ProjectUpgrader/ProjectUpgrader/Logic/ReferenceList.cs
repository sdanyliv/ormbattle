// Copyright (C) 2003-2010 Xtensive LLC.
// All rights reserved.
// For conditions of distribution and use, see license.
// Created by: Alex Yakunin
// Created:    2010.05.19

using System;
using System.Collections.Generic;

namespace ProjectUpgrader.Logic
{
  [Serializable]
  public class ReferenceList : List<Reference>
  {
    public void Add(
      string name, bool removeHintPath = false, bool? specificVersion = null, string requiredTargetFramework = null)
    {
      Add(new Reference(
        name, removeHintPath, specificVersion, requiredTargetFramework));
    }


    // Constructors

    public ReferenceList()
    {
    }

    public ReferenceList(IEnumerable<Reference> collection)
      : base(collection)
    {
    }
  }
}