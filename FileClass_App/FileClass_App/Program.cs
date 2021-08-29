using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FileClass_App
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\Madeeha.Shaikh\source\repos\Training (Bhavana maam)\File IO\MyFile.txt";

            //Exists() - Determines whether the specified file exists.
            if (!File.Exists(path))
            {
                string[] insertText = { "File is a class in the System.IO namespace", "WriteAllLines() method is used to write to a file", "ReadAllLines() method is used to read from a file" };
                //WriteAllLines() - Creates a new file, writes one or more strings to the file, and then closes the file.
                File.WriteAllLines(path, insertText, Encoding.UTF8);
            }

            //ReadAllLines() - Opens a text file, reads all lines of the file into a string array, and then closes the file.
            string[] readText = File.ReadAllLines(path, Encoding.UTF8);
            foreach (string s in readText)
            {
                Console.WriteLine(s);
            }


            string path2 = @"C:\Users\Madeeha.Shaikh\source\repos\Training (Bhavana maam)\File IO\MyFileCopy.txt";
            if (!File.Exists(path2))
            {
                File.Copy(path, path2);
            }

            

            //Appends lines to a file, and then closes the file.
            File.AppendAllLines(path2,readText);

           File.Delete(path2);

            Console.ReadLine();
        }
    }
}
