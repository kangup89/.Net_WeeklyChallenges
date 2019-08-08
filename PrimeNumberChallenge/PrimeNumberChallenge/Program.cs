using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeNumberChallenge
{
    class Program
    {
        private static List<int> globalFactors;
        private static List<int> primeFactors;

        static void Main(string[] args)
        {
            bool end = false;
            
            while (!end)
            {
                Console.Write("Give a number: ");
                int n = 0;

                int.TryParse(Console.ReadLine(), out n);

                startCheck(n); 
            }

            Console.ReadLine();
        }

        public static void startCheck(int n)
        {
            if (checkPrime(n))
            {
                Console.WriteLine("Given number is a prime number");
                Console.WriteLine("");
            }
            else
            {
                List<int> factors = globalFactors;
                primeFactors = new List<int>();

                Console.WriteLine("Given number is not a prime number");
                Console.Write("Factors for a given number: ");
                for (int i = 0; i < factors.Count; i++)
                {
                    Console.Write("{0} ", factors[i]);
                    if (checkPrime(factors[i]))
                    {
                        primeFactors.Add(factors[i]);
                    }
                }
                Console.WriteLine("");

                Console.Write("Prime factors for a given number: ");
                for (int j = 0; j < primeFactors.Count; j++)
                {
                    Console.Write("{0} ", primeFactors[j]);
                }
                Console.WriteLine("");
                Console.WriteLine("");
            }
        }

        public static Boolean checkPrime(int n)
        {
            bool numberIsPrime = true;
            globalFactors = new List<int>();

            for (int i = 2; i < n; i++)
            {
                if (n%i == 0)
                {
                    numberIsPrime = false;
                    globalFactors.Add(i);
                }
            }
            
            return numberIsPrime;      
        }
    }
}
