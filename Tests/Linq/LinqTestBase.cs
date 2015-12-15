// Copyright (C) 2009-2010 ORMBattle.NET.
// All rights reserved.
// For conditions of distribution and use, see license.
// Created by: Alex Yakunin
// Created:    2009.08.31

using System.IO;
using System.Text;

namespace OrmBattle.Tests.Linq
{
    public abstract class LinqTestBase : ToolTestBase
    {
        public override void BaseTearDown()
        {
            base.BaseTearDown();
            if (_isSourceChanged)
                WriteText(SourceFilePath + SourceFileName, _sourceEncoding, _source);
        }

        public const string SourceFilePath = @"..\..\..\Tests\Linq\";
        private string _source;
        private Encoding _sourceEncoding;
        private bool _isSourceChanged;

        public abstract string SourceFileName { get; }

        public string Source
        {
            get
            {
                if (_source == null)
                    _source = ReadText(SourceFilePath + SourceFileName, out _sourceEncoding);
                return _source;
            }
            set
            {
                var nothing = Source; // Ensures original encoding is detected
                if (_source != value)
                {
                    _source = value;
                    _isSourceChanged = true;
                }
            }
        }

        private string ReadText(string path, out Encoding encoding)
        {
            try
            {
                encoding = Encoding.GetEncoding(1251, new EncoderExceptionFallback(), new DecoderExceptionFallback());
                return ReadText2(path, encoding);
            }
            catch (DecoderFallbackException)
            {
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
            try
            {
                WriteText2(path, encoding, text);
            }
            catch (EncoderFallbackException)
            {
                WriteText2(path, Encoding.UTF8, text);
            }
        }

        private void WriteText2(string path, Encoding encoding, string text)
        {
            using (var stream = new FileStream(path, FileMode.Open))
            using (var writer = new StreamWriter(stream, encoding))
            {
                writer.Write(text);
                stream.SetLength(stream.Position);
            }
        }
    }
}