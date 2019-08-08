using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParameterChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            int n;
            InitOut(out n);
            Console.WriteLine(n);

            InitRef(ref n);
            Console.WriteLine(n);

            Tuple<string, int> tuple;
            initTuple(out tuple);
            Console.WriteLine(tuple.Item1);
            Console.WriteLine(tuple.Item2);

            Console.ReadLine();
        }

        public static void InitOut(out int num1)
        {
            num1 = 100;
        }

        public static void InitRef(ref int num1)
        {
            num1 = 102;
        }

        public static void initTuple(out Tuple<string, int> tuple)
        {
            tuple = new Tuple<string, int>("str1", 1);
        }
    }
}
