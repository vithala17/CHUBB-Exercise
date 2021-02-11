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
            const string filePath = "TestTextFile.txt";
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
                    var revTextArray = revText.ToCharArray();
                    Array.Reverse(revTextArray);

                    newString = String.Concat(revTextArray);
                }

                // filePath = "OutputTextFile.txt";
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    //writer.Write(newString);
                    //writer.Flush();

                    writer.WriteLine("C# Corner Authors");
                    writer.WriteLine("==================");
                    writer.WriteLine("Monica Rathbun");
                    writer.WriteLine("Vidya Agarwal");
                    writer.WriteLine("Mahesh Chand");
                    writer.WriteLine("Vijay Anand");
                    writer.WriteLine("Jignesh Trivedi");

                    writer.Flush();
                    writer.Close();
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
