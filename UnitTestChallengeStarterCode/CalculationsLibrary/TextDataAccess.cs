using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CalculationsLibrary
{
    public class TextDataAccess
    {
        public static List<string> SaveText(string filePath, List<string> lines)
        {
            if (filePath.Length > 260)
            {
                throw new PathTooLongException("The path needs to be less than 261 characters long.");
            }

            string fileName = Path.GetFileName(filePath);

            //File.WriteAllLines(fileName, lines);

            List<string> savedLines = new List<string>();
            savedLines.InsertRange(0, lines);

            return savedLines;
        }
    }
}
