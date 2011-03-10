// Copyright (C) 2009-2010 ORMBattle.NET.
// All rights reserved.
// For conditions of distribution and use, see license.
// Created by: Alex Yakunin
// Created:    2010.08.05

using System;
using System.Data;
using System.Diagnostics;
using System.Data.Objects.DataClasses;

namespace OrmBattle.EFModel
{
  public partial class Simplest : EntityObject
  {
    public static Simplest GetById(PerformanceTestEntities dataContext, long id)
    {
      return (Simplest) dataContext.GetObjectByKey(new EntityKey("PerformanceTestEntities.Simplests", "Id", id));
    }
  }
}