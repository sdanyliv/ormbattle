using System;
using System.Security.AccessControl;
using System.Text;
using System.IO;
using Xtensive.Core;

namespace OrmBattle.TestRunner
{
  internal static class JsonWriter
  {
    private readonly static Encoding encoding = new UTF8Encoding();
    private static Stream stream;
    private static BinaryWriter writer;

    public static void Write(string value)
    {
      if (stream==null)
        return;
      stream.Position = stream.Position - 1;
      writer.Write(encoding.GetBytes(value));
      writer.Write(encoding.GetBytes("]"));
      writer.Flush();
      stream.Flush();
    }


    // Constructors

    public static IDisposable Initialize(string fileName)
    {
      stream = File.Create(fileName);
      writer = new BinaryWriter(stream);
      writer.Write(encoding.GetBytes(" "));
      writer.Write("[");
      return writer.Join(stream);
    }
  }
}
