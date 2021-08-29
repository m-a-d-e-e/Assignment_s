using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamReader_StreamWriter_App
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\Madeeha.Shaikh\source\repos\Training (Bhavana maam)\File IO\StreamReaderWriter.txt";

            StreamWriter sw = new StreamWriter(path);

            string str;
            Console.WriteLine("Enter any 3 lines of text that you want to write on File");
            for (int i = 0; i < 3; i++)
            {
                // read the input from the user
                str = Console.ReadLine();

                // write a line in buffer
                sw.WriteLine(str);   
            }

            // write in output stream
            sw.Flush();

            // close the stream
            sw.Close();


            StreamReader sr = new StreamReader(path);

            Console.WriteLine("Content of the File------");

            // This is use to specify from where 
            // to start reading input stream
            sr.BaseStream.Seek(0, SeekOrigin.Begin);

            //read line from input stream
            string line = sr.ReadLine();

            // read the whole file line by line
            while (line != null)
            {
                Console.WriteLine(line);
                line = sr.ReadLine();
            }
            Console.ReadLine();

            //close the stream
            sr.Close();
        }
    }
}
