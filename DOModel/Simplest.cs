// Copyright (C) 2009 ORMBattle.net
// All rights reserved.
// For conditions of distribution and use, see license.
// Created by: Alexis Kochetov
// Created:    2009.07.29

using Xtensive.Storage;

namespace OrmBattle.DOModel
{
  [HierarchyRoot]
  public class Simplest : Entity
  {
    [Field, Key]
    public long Id { get; private set; }

    [Field]
    public long Value { get; set; }


    // Constructors

    public Simplest(long id, long value)
      : base(id)
    {
      Value = value;
    }
  }
}