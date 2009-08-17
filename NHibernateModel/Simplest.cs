// Copyright (C) 2009 Xtensive LLC.
// All rights reserved.
// For conditions of distribution and use, see license.
// Created by: Alexis Kochetov
// Created:    2009.07.29

using System;
using System.Diagnostics;

namespace OrmBattle.NHibernateModel
{
  public class Simplest
  {
    public virtual long Id { get; set; }
    public virtual long Value { get; set; }


    // Constructors

    public Simplest()
    {}

    public Simplest(long id, long value)
    {
      Id = id;
      Value = value;
    }
  }
}