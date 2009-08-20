using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrmBattle.Tests.Performance;

namespace OrmBattle.TestRunner
{
  internal class Program
  {
    private static void Main(string[] args)
    {
      var performanceTestRunner = new PerformanceTestRunner(50, 100, 500, 1000, 5000, 10000, 30000);
      var linqTestRunner = new LinqTestRunner();

      performanceTestRunner.Run();
      linqTestRunner.Run();
    }
  }
}