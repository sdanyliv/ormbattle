// Copyright (C) 2009-2010 ORMBattle.NET.
// All rights reserved.
// For conditions of distribution and use, see license.
// Created by: Alex Yakunin
// Created:    2010.06.10

using System;
using System.Diagnostics;

namespace OrmBattle.EFModel
{
  public partial class NorthwindEntities
  {
    /// <summary>
    /// There are no comments for DiscontinuedProducts in the schema.
    /// </summary>
    public global::System.Data.Objects.ObjectQuery<DiscontinuedProduct> DiscontinuedProducts
    {
      get
      {
        if ((this._DiscontinuedProducts == null))
        {
          this._DiscontinuedProducts = base.CreateQuery<DiscontinuedProduct>("[Products]");
        }
        return this._DiscontinuedProducts;
      }
    }
    private global::System.Data.Objects.ObjectQuery<DiscontinuedProduct> _DiscontinuedProducts;

    /// <summary>
    /// There are no comments for ActiveProducts in the schema.
    /// </summary>
    public global::System.Data.Objects.ObjectQuery<ActiveProduct> ActiveProducts
    {
      get
      {
        if ((this._ActiveProducts == null))
        {
          this._ActiveProducts = base.CreateQuery<ActiveProduct>("[Products]");
        }
        return this._ActiveProducts;
      }
    }
    private global::System.Data.Objects.ObjectQuery<ActiveProduct> _ActiveProducts;
  }
}