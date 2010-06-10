// Copyright (C) 2009-2010 ORMBattle.NET.
// All rights reserved.
// For conditions of distribution and use, see license.
// Created by: Alexis Kochetov
// Created:    2009.08.02

using System;
using System.Diagnostics;
using SubSonic.Query;
using SubSonic.Repository;

namespace OrmBattle.SubsonicModel.PerformanceTest
{
  [Serializable]
  public class SimplestRepository : SubSonicRepository<Simplest>
  {
    public SimplestRepository(IQuerySurface db) : base(db)
    {}
  }
}