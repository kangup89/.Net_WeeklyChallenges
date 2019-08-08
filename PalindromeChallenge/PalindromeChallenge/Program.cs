using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalindromeChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            checkPalindrome("stack cats");
            checkPalindrome("aple");
            checkPalindrome(123224);
            checkPalindrome(3562343);
            checkPalindrome(2.7216879);
            checkPalindrome(3.5623433);

            Console.ReadLine();
        }

        public static void checkPalindrome(string word)
        {
            List<Char> chars = word.ToList();

            if (chars[0] == chars[(chars.Count - 1)])
            {
                Console.WriteLine("The word '{0}' is a palindrome!", word);
            }
            else
            {
                Console.WriteLine("The word '{0}' is not a palindrome!", word);
            }
        }

        public static void checkPalindrome(int number)
        {
            List<Char> chars = number.ToString().ToList();

            if (chars[0] == chars[(chars.Count - 1)])
            {
                Console.WriteLine("The number '{0}' is a palindrome!", number);
            }
            else
            {
                Console.WriteLine("The number '{0}' is not a palindrome!", number);
            }
        }
        public static void checkPalindrome(double doub)
        {
            List<Char> chars = doub.ToString().ToList();

            if (chars[0] == chars[(chars.Count - 1)])
            {
                Console.WriteLine("The double '{0}' is a palindrome!", doub);
            }
            else
            {
                Console.WriteLine("The double '{0}' is not a palindrome!", doub);
            }
        }
    }
}
