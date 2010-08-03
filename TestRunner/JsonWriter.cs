using System;
using System.Text;
using System.IO;

namespace OrmBattle.TestRunner
{
  internal class JsonWriter : BinaryWriter
  {
    private readonly static Encoding encoding = new UTF8Encoding();

    public override void Write(string value)
    {
      BaseStream.Position = BaseStream.Position - 1;
      base.Write(encoding.GetBytes(value));
      base.Write(encoding.GetBytes("]"));
      Flush();
    }


    // Constructors

    public JsonWriter(Stream file)
      : base(file)
    {
      base.Write(encoding.GetBytes(" "));
      Write("[");
    }
  }
}
