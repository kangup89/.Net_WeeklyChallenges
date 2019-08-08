using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorrectChangeChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                int owed = -1;
                int paid = -1;

                Console.Write("Give an amount owed: ");

                int.TryParse(Console.ReadLine(), out owed);

                Console.Write("Give an amount paid: ");

                int.TryParse(Console.ReadLine(), out paid);

                int change = calculation(owed, paid);

                int bill50 = change / 50;
                int bill5 = (change % 50) / 5;
                int bill1 = (change % 5);

                if (change == -1)
                {
                    Console.WriteLine("Format error or amount owed is larger than amount paid");
                }
                else
                {
                    Console.WriteLine("Change is {0}, and consists of {1} $50 bills, {2} $5 bills and {3} $1 bills.", change, bill50, bill5, bill1);
                }

                Console.WriteLine();
            }

            Console.ReadLine();
        }

        public static int calculation(int owed, int paid)
        {
            int change = -1;

            if (owed != -1 && paid != -1 && paid >= owed)
            {
                change = paid - owed;
            }

            return change;
        }
    }
}
