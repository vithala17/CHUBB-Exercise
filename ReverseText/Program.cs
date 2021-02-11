using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Linq;
using System.Text;

namespace ReverseText
{
    // IMPORTANT: make sure you read the instructions in README.md

    class Program
    {
        static void Main(string[] args)
        {
            var path = Directory.GetCurrentDirectory();
            var builder = new ConfigurationBuilder()
                    .SetBasePath(path)
                    .AddJsonFile("appsettings.json", false, true);
            var config = builder.Build();

            string filePath = config["FileRelativepath"] + "TestTextFile.txt";
            FileTextReverser textReverser = new FileTextReverser();

            string text = textReverser.ReverseFileContents(filePath);

            Console.WriteLine(text);
        }
    }

    public class FileTextReverser
    {
        public string ReverseFileContents(string filePath)
        {
            try
            {
                string revText, newString = "";
                // TODO: read text file, reverse the text, save reversed text back to the same file

                using (StreamReader reader = new StreamReader(filePath))
                {
                    revText = reader.ReadToEnd();

                    if (string.IsNullOrEmpty(revText) || revText.Length == 1)
                        return revText;

                    var revTextArray = revText.ToCharArray();
                    Array.Reverse(revTextArray);

                    newString = String.Concat(revTextArray);
                }

                // filePath = "OutputTextFile.txt";
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    writer.Write(newString);
                    writer.Flush();
                }

                // TODO: return the reversed text
                return newString;
            }
            catch (Exception ex)
            {

                throw;
            }

        }
    }
}
