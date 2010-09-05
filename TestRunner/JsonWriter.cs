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
    private static string EndMarker = "])";
    private static bool FirstRecord = true;

    public static void Write(string value)
    {
      if (stream==null)
        return;
      stream.Position = stream.Position - EndMarker.Length;
      if (!FirstRecord) writer.Write(encoding.GetBytes(","));
      else FirstRecord = false;
      writer.Write(encoding.GetBytes(value));
      writer.Write(encoding.GetBytes(EndMarker));
      writer.Flush();
      stream.Flush();
    }


    // Constructors

    public static IDisposable Initialize(string fileName)
    {
      stream = File.Create(fileName);
      writer = new BinaryWriter(stream);
      writer.Write(encoding.GetBytes("ResultToMemory(["+EndMarker));
      return writer.Join(stream);
    }
  }
}
