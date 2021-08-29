using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryReader_BinaryWriter_App
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\Madeeha.Shaikh\source\repos\Training (Bhavana maam)\File IO\Binary.txt";

            //BinaryWriter - Writes primitive types in binary to a stream and supports writing strings in a specific encoding.

            using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate)))
            {
                writer.Write(12.5);
                writer.Write("this is string data");
                writer.Write(true);
                writer.Write(1.250F);
            }



            //BinaryReader - Reads primitive data types as binary values in a specific encoding.

            if (File.Exists(path))
            {
                using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open)))
                {
                    Console.WriteLine("Double Value : " + reader.ReadDouble());
                    Console.WriteLine("String Value : " + reader.ReadString());
                    Console.WriteLine("Boolean Value : " + reader.ReadBoolean());
                    Console.WriteLine("Float Value : " + reader.ReadSingle());
                }
            }

            Console.ReadLine();
        }
    }
}
