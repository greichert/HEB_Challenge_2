using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HEB_Challenge_2
{
    class FileParser
    {
        public bool? HasErrors;
        public List<string> ErrorCodes;      
        public StringBuilder OutputBuilder;

        public FileParser(string InputPath, string OutputPath)
        {
            //initialize variables
            Dictionary<string, int> results = new Dictionary<string, int>();
            OutputBuilder = new StringBuilder();
            HasErrors = null;
            ErrorCodes = new List<string>();

            // use try catch in case of errors
            try
            {
                // open file and read text
                string[] myText = File.ReadAllLines(InputPath);
                foreach (var line in myText)
                {
                    // breakdown text into results
                    string[] words = line.Split(' ');

                    foreach (var word in words)
                    {
                        //strip punctuation and formatting
                        string formattedWord = word.ToLower();
                        formattedWord = formattedWord.Trim();
                        foreach(char punctChar in formattedWord)
                        {
                            if(Char.IsPunctuation(punctChar))
                            {
                                formattedWord = formattedWord.Replace(punctChar.ToString(), string.Empty);
                            }
                        }
                        // initialize variables
                        int value = 0;
                        bool check = results.TryGetValue(formattedWord, out value);
                        if (check)
                        {
                            // increment value
                            results[formattedWord] = value + 1;
                        }
                        else
                        {
                            // add new entry
                            results.Add(formattedWord, 1);
                        }
                    }
                }

                // create output
                if (results.Count() > 0)
                {
                    foreach (var result in results.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                    {
                        
                        OutputBuilder.Append(result.Key + " | ");
                        for (int count = result.Value; count > 0; count--)
                        {
                            OutputBuilder.Append("=");
                        }
                        OutputBuilder.AppendLine(" " + result.Value.ToString());
                    }
                }

                // move output text to file, auto closes
                File.WriteAllText(OutputPath, OutputBuilder.ToString());

                // set finished properties
                this.HasErrors = false;
            }
            catch (Exception ex)
            {
                this.HasErrors = true;
                this.ErrorCodes.Add(ex.ToString());
            }
        }
    }
}
