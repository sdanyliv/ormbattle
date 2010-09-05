using System;
using System.Security.AccessControl;
using System.Text;
using System.IO;
using Xtensive.Core;

namespace OrmBattle.TestRunner
{
  internal static class JsonWriter
  {
    private static string Prefix = "ResultToMemory([";
    private static string Comma = ",";
    private static string Suffix = "])";

    private readonly static Encoding encoding = new UTF8Encoding();
    private static Stream stream;
    private static BinaryWriter writer;
    private static bool firstRecord = true;

    public static void Write(string value)
    {
      if (stream==null)
        return;
      stream.Position = stream.Position - Suffix.Length;
      if (!firstRecord) 
        writer.Write(encoding.GetBytes(Comma));
      else 
        firstRecord = false;
      writer.Write(encoding.GetBytes(value));
      writer.Write(encoding.GetBytes(Suffix));
      stream.SetLength(stream.Position);
      writer.Flush();
      stream.Flush();
    }


    // Constructors

    public static IDisposable Initialize(string fileName)
    {
      stream = File.Create(fileName);
      writer = new BinaryWriter(stream);
      writer.Write(encoding.GetBytes(Prefix + Suffix));
      return writer.Join(stream);
    }
  }
}
