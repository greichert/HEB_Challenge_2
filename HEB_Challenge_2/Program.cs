using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HEB_Challenge_2
{
    class Program
    {
        static void Main(string[] args)
        {
            //string InputPath = "E:\\Projects\\HEBChallenge2\\HEB_Challenge_2\\HEB_Challenge_2\\Files\\Input.txt";
            //string OutputPath = "E:\\Projects\\HEBChallenge2\\HEB_Challenge_2\\HEB_Challenge_2\\Files\\Output.txt";
            string rootPath = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
            string InputPath = rootPath + "\\Files\\Input.txt";
            string OutputPath = rootPath + "\\Files\\Output.txt";

            var parser = new FileParser(InputPath, OutputPath);

            Console.WriteLine(parser.HasErrors.ToString());
            Console.WriteLine(parser.ErrorCodes.ToString());
        }
    }
}
