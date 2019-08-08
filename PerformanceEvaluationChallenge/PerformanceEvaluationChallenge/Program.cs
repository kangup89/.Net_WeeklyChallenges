using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceEvaluationChallenge
{
    class Program
    {
        public static Stopwatch sw = new Stopwatch();

        static void Main(string[] args)
        {
            startTest();

            Console.ReadLine();
        }

        public static void startTest()
        {
            bool end = false;

            int i = 0;

            while (!end)
            {
                Console.Write("Give a test value (q for end): ");
                string value = Console.ReadLine().ToString();

                bool result = int.TryParse(value, out i);

                if (value == "q")
                {
                    end = true;
                    Console.WriteLine("test end!");
                }
                else if (result)
                {
                    decimal dec = decimal.Parse(value.ToString());
                    double dob = double.Parse(value.ToString());

                    addDouble(dob, 500000);
                    addDouble(dob, 5000000);

                    addDecimal(dec, 500000);
                    addDecimal(dec, 5000000);
                }
                else
                {
                    string st = value.ToString();
                    appendText(st, 500);
                    appendText(st, 5000);
                    appendText(st, 50000);

                    stringBuilder(st, 500);
                    stringBuilder(st, 5000);
                    stringBuilder(st, 50000);
                }
            }
        }

        public static void appendText(string st, int n)
        {
            string output = "";

            sw.Reset();
            sw.Start();

            for (int i = 0; i < n; i++)
            {
                output = string.Concat(output, st);
            }

            sw.Stop();

            Console.WriteLine("Append Text {0} reps: {1} ms", n, sw.ElapsedMilliseconds.ToString());
        }

        public static void stringBuilder(string st, int n)
        {
            StringBuilder output = new StringBuilder();

            sw.Reset();
            sw.Start();

            for (int i = 0; i < n; i++)
            {
                output.Append(st); 
            }

            sw.Stop();

            Console.WriteLine("String Builder {0} reps: {1} ms", n, sw.ElapsedMilliseconds.ToString());
        }

        public static void addDecimal(decimal dec, int n)
        {
            decimal output = 0;

            sw.Reset();
            sw.Start();

            for (int i = 0; i < n; i++)
            {
                output += dec;
            }

            sw.Stop();

            Console.WriteLine("Decimal {0} reps: {1} ms", n, sw.ElapsedMilliseconds.ToString());
        }

        public static void addDouble(double dob, int n)
        {
            double output = 0;

            sw.Reset();
            sw.Start();

            for (int i = 0; i < n; i++)
            {
                output += dob;
            }

            sw.Stop();

            Console.WriteLine("Double {0} reps: {1} ms", n, sw.ElapsedMilliseconds.ToString());
        }
    }
}
