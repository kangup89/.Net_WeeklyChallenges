using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzzChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            List<KeyValuePair<int, string>> fizzbuzz = new List<KeyValuePair<int, string>>();

            fizzbuzz.Add(new KeyValuePair<int, string> ( 15, "FizzBuzz" ));
            fizzbuzz.Add(new KeyValuePair<int, string> ( 3, "Fizz" ));
            fizzbuzz.Add(new KeyValuePair<int, string> ( 5, "Buzz" ));
            fizzbuzz.Add(new KeyValuePair<int, string> ( 7, "Jazz" ));

            startFizzBuzz(fizzbuzz);

            Console.ReadLine();
        }

        public static void startFizzBuzz(List<KeyValuePair<int, String>> fizzbuzz)
        {
            for (int i = 1; i <= 100; i++)
            {
                bool found = false;
                
                for (int j = 0; j < fizzbuzz.Count; j++)
                {
                    if (check(i, fizzbuzz[j].Key))
                    {
                        Console.WriteLine("{0} ({1})", fizzbuzz[j].Value, i);
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    Console.WriteLine(i);
                }
            }
        }

        public static Boolean check(int i, int n)
        {
            if (i%n == 0)
            {
                return true;
            }

            return false;
        }
    }
}
