using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringReader_StringWriter_App
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();

            /*
             StringWriter class is used to write and deal with string data rather than files. It is derived class of TextWriter class. 
             The string data written by StringWriter class is stored into StringBuilder.
             The purpose of this class is to manipulate string and save result into the StringBuilder.
            */

            StringWriter sw = new StringWriter(sb);
            Console.WriteLine("Please enter the details...");
            Console.Write("Name :");

            //Get the name from the console
            string name = Console.ReadLine();
            //Write to StringBuilder
            sw.WriteLine("Name :" + name);

            Console.Write("Country :");
            string country = Console.ReadLine();
            //Write to StringBuilder
            sw.WriteLine("Country :" + country);

            Console.Write("Age :");
            string age = Console.ReadLine();
            //Write to StringBuilder
            sw.WriteLine("Age :" + age);
            
            Console.WriteLine("Information Saved!!!!");
            Console.WriteLine();

            //Close the stream
            sw.Flush();
            sw.Close();


            //StringReader class is used to read data written by the StringWriter class. It is subclass of TextReader class.

            StringReader sr = new StringReader(sb.ToString());
            Console.WriteLine("Reading data from string........");

            //Peek to see if the next character exists
            while (sr.Peek() > -1)
            {
                //Read a line from the string 
                Console.WriteLine(sr.ReadLine());
            }

            //Close the stream
            sr.Close();

            Console.ReadLine();
        }
    }
}
