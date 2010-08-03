using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace OrmBattle.TestRunner
{
    class JsonWriter:BinaryWriter
    {
        UTF8Encoding Enc;
        public JsonWriter(Stream file):base(file)
        {
            Enc = new UTF8Encoding();
            base.Write(Enc.GetBytes(" "));
            this.Write("[");
        }



        public override void Write(string value)
        {
            this.BaseStream.Position = BaseStream.Position - 1;
            base.Write(Enc.GetBytes(value));
            base.Write(Enc.GetBytes("]"));
            Flush();
        }
    }
}
