using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    class Program
    {
        private static string[] tests = new string[]
        {
            @"The test of the 
            best way to handle

multiple lines,   extra spaces and more.",
            @"Using the starter app, create code that will 
loop through the strings and identify the total 
character count, the number of characters
excluding whitespace (including line returns), and the
number of words in the string. Finally, list each word, ensuring it
is a valid word."
        };

        /* 
            First string (tests[0]) Values:
            Total Words: 14
            Total Characters: 89
            Character count (minus line returns and spaces): 60
            Most used word: the (2 times)
            Most used character: e (10 times)

            Second string (tests[1]) Values:
            Total Words: 45
            Total Characters: 276
            Character count (minus line returns and spaces): 230
            Most used word: the (6 times)
            Most used character: t (24 times)
        */

        static void Main(string[] args)
        {
            Console.WriteLine("First string (test[0]) Values: ");
            StartCount(tests[0]);

            Console.WriteLine();

            Console.WriteLine("Second string (test[1]) Values: ");
            StartCount(tests[1]);

            Console.ReadLine();
        }

        public static void StartCount(string str)
        {
            char[] separator = new char[] { '\t', '\n', ' ' };
            List<string> trimmedWords = TrimString(str.Split(separator).ToList());

            Console.WriteLine("Total Words: {0}", trimmedWords.Count());

            List<char> chars = WordsToChars(str.Split('\n').ToList());
            List<char> trimmedChars = WordsToChars(trimmedWords);

            Console.WriteLine("Total Characters: {0}", chars.Count());
            Console.WriteLine("Character count (minus line returns and spaces): {0}", trimmedChars.Count());

            CountMostUsedWord(trimmedWords);
            CountMostUsedChar(trimmedChars);
        }

        public static List<string> TrimString(List<string> words)
        {
            List<string> result = new List<string>();
            string str;

            for (int i = 0; i < words.Count(); i++)
            {
                str = words[i].Trim().Replace("\t", "");
                if (str != "")
                {
                    result.Add(str);
                }
            }

            return result;
        }

        public static List<char> WordsToChars(List<string> strs)
        {
            List<char> chars = new List<char>();

            char[] charArray;

            foreach (var str in strs)
            {
                charArray = str.ToCharArray();
                foreach (var cha in charArray)
                {
                    chars.Add(cha);
                }
            }

            return chars;
        }

        public static void CountMostUsedWord(List<string> words)
        {
            int n = 0;
            int count = 0;
            string mostUsedWord = "";

            foreach (var word in words)
            {
                n = words.Where(x => (x.ToLower() == word.ToLower())).Count();
                if (n > count)
                {
                    count = n;
                    mostUsedWord = word.ToLower();
                }
            }

            Console.WriteLine("Most used word: {0} ({1} times)", mostUsedWord, count);
        }

        public static void CountMostUsedChar(List<char> chars)
        {
            int n = 0;
            int count = 0;
            char mostUsedChar = ' ';

            foreach (var ch in chars)
            {
                n = chars.Where(x => (char.ToLower(x) == char.ToLower(ch))).Count();
                if (n > count)
                {
                    count = n;
                    mostUsedChar = char.ToLower(ch);
                }
            }

            Console.WriteLine("Most used character: {0} ({1} times)", mostUsedChar, count);
        }
    }
}
