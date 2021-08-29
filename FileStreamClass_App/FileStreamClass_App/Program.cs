using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileStreamClass_App
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\Madeeha.Shaikh\source\repos\Training (Bhavana maam)\File IO\MyFileStream.txt";

            // Delete the file if it exists.
            if (File.Exists(path))
            {
                File.Delete(path);
            }

            int i;
            FileStream f = new FileStream(path, FileMode.OpenOrCreate);
            for (i = 65; i <= 70; i++)
            {
                f.WriteByte((byte)i);
            }

            f.Seek(0, SeekOrigin.Begin);

            while ((i = f.ReadByte()) != -1)
            {
                Console.WriteLine((char)i);
            }

            f.Close();

            Console.ReadLine();
        }
    }
}
