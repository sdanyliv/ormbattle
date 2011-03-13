// Copyright (C) 2003-2010 Xtensive LLC.
// All rights reserved.
// For conditions of distribution and use, see license.
// Created by: Alex Yakunin
// Created:    2010.05.20

using System;
using System.Diagnostics;
using System.Windows;

namespace ProjectUpgrader
{
  public static class ErrorReporter
  {
    public static void Report(Exception error)
    {
      Console.WriteLine("_______________________________________________________________________________");
      Console.WriteLine("Error:  {0}", error.Message);
      Console.WriteLine("Source: {0}", error);
      Console.WriteLine("_______________________________________________________________________________");
      Console.WriteLine();
      MessageBox.Show(error.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
    }
  }
}