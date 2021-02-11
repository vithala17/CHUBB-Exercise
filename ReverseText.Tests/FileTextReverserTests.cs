using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;
using Moq;

namespace ReverseText.Tests
{
    public class FileTextReverserTests
    {
        FileTextReverser fileTextReverserObj = null;

        public FileTextReverserTests()
        {
            fileTextReverserObj = new FileTextReverser();
        }


        /// <summary>
        /// Purpose : Method Should return reversed text of the file content
        /// </summary>
        [Fact]
        public void ReverseFileContents_ShouldReturnReversedTextOfTheFileContent()
        {
            string filepath = "TestTextFile.txt";
            StreamReader reader = new StreamReader(filepath);
            string text = reader.ReadToEnd();
            reader.Close();

            var tempArray = text.ToCharArray();
            Array.Reverse(tempArray);

            string expected = String.Concat(tempArray);
            string actual = fileTextReverserObj.ReverseFileContents(filepath);

            Assert.Equal(expected, actual);
        }

        /// <summary>
        /// Purpose : Method should return empty if file doesnt contain any text
        /// </summary>
        [Fact]
        public void ReverseFileContents_ShouldreturnEmptyIfFileDoesntContainAnyText()
        {
            string filepath = "TestTextFile.txt";
            StreamWriter writer = new StreamWriter(filepath);
            writer.Write("");
            writer.Flush();
            writer.Close();

            string expected = "";
            string actual = fileTextReverserObj.ReverseFileContents(filepath);

            Assert.Equal(expected,actual);
        }

        /// <summary>
        /// Purpose : Method should return same content if only one character is in the file
        /// </summary>
        [Fact]
        public void ReverseFileContents_ShouldReturnSameContentWhenThereIsOnlyOnecharacterInTheFile()
        {
            string filepath = "TestTextFile.txt";
            StreamWriter writer = new StreamWriter(filepath);
            writer.Write("A");
            writer.Flush();
            writer.Close();

            string expected = "A";
            string actual = fileTextReverserObj.ReverseFileContents(filepath);

            Assert.Equal(expected, actual);
        }

        /// <summary>
        /// Purpose : Method should IOException when file/stream is busy
        /// </summary>
        [Fact]
        public void ReverseFileContents_ShouldThrowIOEcxeptionWhenFileStreamIsBusy()
        {
            string filepath = "TestTextFile.txt";
            StreamWriter writer = new StreamWriter(filepath);
            writer.Write("A");

            Assert.Throws<System.IO.IOException>(() => fileTextReverserObj.ReverseFileContents(filepath));
            writer.Close();
        }

    }
}
