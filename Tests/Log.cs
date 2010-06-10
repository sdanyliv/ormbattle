// Copyright (C) 2009-2010 ORMBattle.NET.
// All rights reserved.
// For conditions of distribution and use, see license.
// Created by: Alexis Kochetov
// Created:    2009.07.29

using System.Reflection;
using Xtensive.Core.Diagnostics;

namespace OrmBattle.Tests
{
  /// <summary>
  /// Log for this namespace.
  /// </summary>
  public sealed class Log : LogTemplate<Log>
  {
    // Copy-paste this code!
    /// <summary>
    /// Gets the name of this log.
    /// </summary>
    public static readonly string Name;

    static Log()
    {
      string className = MethodBase.GetCurrentMethod().DeclaringType.FullName;
      Name = className.Substring(0, className.LastIndexOf('.'));
    }
  }
}