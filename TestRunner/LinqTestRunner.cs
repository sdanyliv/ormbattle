// Copyright (C) 2009 ORMBattle.net
// All rights reserved.
// For conditions of distribution and use, see license.
// Created by: Alexis Kochetov
// Created:    2009.08.11

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using NUnit.Framework;
using OrmBattle.Tests.Linq;
using Xtensive.Core.Collections;


namespace OrmBattle.TestRunner
{
  [Serializable]
  public class LinqTestRunner
  {
    public void Run()
    {
      Console.Out.WriteLine("Linq tests:");
      Console.Out.WriteLine();
      var tests = new List<object>
                  {
                    new EFTest(), 
                    new DOTest(),
                    new LightSpeedTest(),
                    new NHibernateTest(),
                    new OpenAccessTest()
                  };

      foreach (var test in tests) {
        var total = 0;
        var failed = 0;
        var assertsFailed = 0;
        var type = test.GetType();
        try {
          var setup = type.GetMethod("Setup");
          setup.Invoke(test, ArrayUtils<object>.EmptyArray);
          foreach (var testMethod in type.GetMethods().Where(mi => mi.IsDefined(typeof (TestAttribute), false))) {
            try {
              total++;
              testMethod.Invoke(test, ArrayUtils<object>.EmptyArray);
            }
            catch(Exception e) {
              failed++;
              var targetInvocationException = e as TargetInvocationException;
              if (targetInvocationException != null &&
                targetInvocationException.InnerException.GetType() == typeof(AssertionException))
                assertsFailed++;
            }
          }
        }
        finally {
          Console.Out.WriteLine(string.Format("Passed: {0} out of {1}; failed with assertion: {2}. LINQ score: {3}%.", total - failed, total, assertsFailed, (total - failed) * 100 / total));
          Console.Out.WriteLine();
          var tearDown = type.GetMethod("TearDown");
          tearDown.Invoke(test, ArrayUtils<object>.EmptyArray);
        }
      }
    }
  }
}