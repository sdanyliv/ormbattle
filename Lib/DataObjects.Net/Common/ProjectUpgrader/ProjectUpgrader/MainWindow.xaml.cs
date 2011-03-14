// Copyright (C) 2003-2010 Xtensive LLC.
// All rights reserved.
// For conditions of distribution and use, see license.
// Created by: Alex Yakunin
// Created:    2010.05.19

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using ProjectUpgrader.Logic;

namespace ProjectUpgrader
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public UpgradeConfiguration UpgradeConfiguration { get; set; }

    public MainWindow()
    {
      InitializeComponent();
    }

    private void Window_Initialized(object sender, EventArgs e)
    {
      UpgradeConfiguration = new UpgradeConfiguration();
      var cfg = UpgradeConfiguration;
      cfg.UpdateByCommandLine();
      bool extractOptions = cfg.Options.ExtractOptions && cfg.SourcePath!=null;
      if (extractOptions) {
        ExtractOptions();
        cfg.UpdateByCommandLine();
      }
      if (cfg.Options.Auto) {
        var upgrader = new Upgrader(cfg);
        upgrader.Process();
        Close();
//        if (Debugger.IsAttached)
//          Console.ReadLine();
      }
      else if (!extractOptions) {
        // Let's suggest these options by default in UI
        cfg.Options.AddImports = true;
        cfg.Options.AddReferences = true;
      }
      Refresh();
    }

    private void bCancel_Click(object sender, RoutedEventArgs e)
    {
      Close();
    }

    private void bBrowse_Click(object sender, RoutedEventArgs e)
    {
      // Configure open file dialog box
      var fileDialog = new OpenFileDialog();
      fileDialog.FileName = UpgradeConfiguration.SourcePath;
      fileDialog.DefaultExt = ".csproj";
      fileDialog.AddExtension = true;
      fileDialog.Filter = 
        "C# projects (.csproj)|*.csproj|" + 
        "F# projects (.fsproj)|*.csproj|" + 
        "VB.NET projects (.vbproj)|*.vbproj";

      if (fileDialog.ShowDialog()==true) {
        UpgradeConfiguration.SourcePath = fileDialog.FileName;
        ExtractOptions();
        Refresh();
      }
    }

    private void bBrowseSln_Click(object sender, RoutedEventArgs e)
    {
      // Configure open file dialog box
      var fileDialog = new OpenFileDialog();
      fileDialog.FileName = UpgradeConfiguration.SolutionPath;
      fileDialog.DefaultExt = ".sln";
      fileDialog.AddExtension = true;
      fileDialog.Filter = 
        "Visual Studio .NET Solution (.sln)|*.sln";

      if (fileDialog.ShowDialog()==true) {
        UpgradeConfiguration.SolutionPath = fileDialog.FileName;
        Refresh();
      }
    }

    private void bOk_Click(object sender, RoutedEventArgs e)
    {
      try {
        var cfg = UpgradeConfiguration;
        var upgrader = new Upgrader(cfg);
        upgrader.Process();
      }
      catch (Exception error) {
        ErrorReporter.Report(error);
        return;
      }
      MessageBox.Show("Operation has completed successfully.", "Operation result", MessageBoxButton.OK, MessageBoxImage.Information);
      Close();
    }

    private void ExtractOptions()
    {
      var cfg = UpgradeConfiguration;
      var upgrader = new Upgrader(cfg);
      upgrader.ExtractOptions();
    }

    private void Refresh()
    {
      DataContext = null;
      DataContext = UpgradeConfiguration;
    }
  }
}
