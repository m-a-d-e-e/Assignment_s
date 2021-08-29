using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextReader_TextWriter_App
{
    class Program
    {
        static void Main(string[] args)
        {
            using (TextWriter writer = File.CreateText(@"C:\Users\Madeeha.Shaikh\source\repos\Training (Bhavana maam)\File IO\TextReaderWriter.txt"))
            {
                writer.WriteLine("The TextWriter class is an abstract class. Therefore, you do not instantiate it in your code."); 
                writer.WriteLine("File.CreateText() methods creates or opens a file for writing UTF-8 encoded text.\nIf the file already exists, its contents are overwritten.");
                writer.WriteLine("WriteLine() method writes data to the text stream, followed by a line terminator.");
            }
            Console.WriteLine("Data written successfully...\n");

            Console.WriteLine("Content of file......\n");
            using (TextReader tr = File.OpenText(@"C:\Users\Madeeha.Shaikh\source\repos\Training (Bhavana maam)\File IO\TextReaderWriter.txt"))
            {
                Console.WriteLine(tr.ReadToEnd());
            }

            Console.ReadLine();
        }
    }
}
