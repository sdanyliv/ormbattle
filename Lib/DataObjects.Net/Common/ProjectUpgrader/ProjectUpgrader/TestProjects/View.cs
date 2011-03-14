// Copyright (C) 2010 Xtensive LLC.
// All rights reserved.
// For conditions of distribution and use, see license.
// Created by: Alex Yakunin
// Created:    2010.04.07

using System;
using System.Web.Mvc;
using Xtensive.Core;
using Xtensive.Core.Collections;
using Xtensive.Core.Aspects.Helpers;
using Xtensive.Integrity.Aspects;
using Xtensive.Integrity.Aspects.Constraints;
using Xtensive.Storage;
using Xtensive.Storage.Upgrade;
using Xtensive.Storage.Model;
using Xtensive.Storage.Rse;
using Xtensive.Storage.Rse.Compilation;
using Xtensive.Storage.Providers;
using Xtensive.Storage.Providers.Indexing;
using Xtensive.Storage.Providers.Sql;
using Xtensive.Storage.Indexing.Model;
using T = Xtensive.Storage.Test;
using IM = Xtensive.Storage.Indexing.Model;

using Xtensive.Integrity.Wrong;
using Xtensive.Integrity.Aspects.Wrong;
using Xtensive.Integrity;

namespace AspNetMvcSample.Models
{
}