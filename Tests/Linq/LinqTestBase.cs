// Copyright (C) 2009 Xtensive LLC.
// All rights reserved.
// For conditions of distribution and use, see license.
// Created by: Alex Yakunin
// Created:    2009.08.31

using System;
using System.IO;
using System.Text;
using Xtensive.Core;

namespace OrmBattle.Tests.Linq
{
  public abstract class LinqTestBase : ToolTestBase
  {
    public const string SourceFilePath = @"..\..\..\Tests\Linq\";
    private string source;
    private Encoding sourceEncoding;
    private bool isSourceChanged;

    public abstract string SourceFileName { get; }

    public string Source {
      get {
        if (source==null)
          source = ReadText(SourceFilePath + SourceFileName, out sourceEncoding);
        return source;
      }
      set {
        string nothing = Source; // Ensures original encoding is detected
        if (source!=value) {
          source = value;
          isSourceChanged = true;
        }
      }
    }

    public override void BaseTearDown()
    {
      base.BaseTearDown();
      if (isSourceChanged)
        WriteText(SourceFilePath + SourceFileName, sourceEncoding, source);
    }

    private string ReadText(string path, out Encoding encoding)
    {
      try {
        encoding = Encoding.GetEncoding(1251, new EncoderExceptionFallback(), new DecoderExceptionFallback());
        return ReadText2(path, encoding);
      }
      catch (DecoderFallbackException e1) {
        encoding = Encoding.UTF8;
        return ReadText2(path, encoding);
      }
    }

    private string ReadText2(string path, Encoding encoding)
    {
      using (var stream = new FileStream(path, FileMode.Open))
      using (var reader = new StreamReader(stream, encoding))
        return reader.ReadToEnd();
    }

    private void WriteText(string path, Encoding encoding, string text)
    {
      try {
        WriteText2(path, encoding, text);
      }
      catch (EncoderFallbackException e) {
        WriteText2(path, Encoding.UTF8, text);
      }
    }

    private void WriteText2(string path, Encoding encoding, string text)
    {
      using (var stream = new FileStream(path, FileMode.OpenOrCreate))
      using (var writer = new StreamWriter(stream, encoding)) {
        writer.Write(text);
        stream.SetLength(stream.Position);
      }
    }
  }
}