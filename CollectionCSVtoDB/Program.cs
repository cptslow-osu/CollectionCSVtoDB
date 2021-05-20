    using System;
using System.Collections.Generic;
using System.IO;

namespace CollectionCSVtoDB
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter File Path:");
            string fpath = @""+ Console.ReadLine();
            string fileName = Path.GetFileNameWithoutExtension(fpath);
            string[] lines = System.IO.File.ReadAllLines(fpath);
            List<string> md5 = new List<string>();
            foreach (string line in lines)
            {
                var values = line.Split(",");
                md5.Add(values[2]);
            }
            int length = md5.Count;
            BinaryWriter BinWriter = new BinaryWriter(File.Create(fileName + ".db"));
            BinWriter.Write((int)DateTime.Now.Ticks);
            BinWriter.Write(1);
            BinWriter.Write((byte)0x0b);
            BinWriter.Write(fileName);
            BinWriter.Write(length);
            for (int i=0; i<length; i++) {
                BinWriter.Write((byte)0x0b);
                BinWriter.Write(md5[i]);
            }
            BinWriter.Close();
        }
    }
}
