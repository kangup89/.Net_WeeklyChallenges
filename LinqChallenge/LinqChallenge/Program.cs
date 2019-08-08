using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqChallenge
{
    class Program
    {
        public static void Main(string[] args)
        {
            string test = "riouxcmvlsfppitelt;kjiil23";

            List<CharacterCount> list = CreateLinq2(test);

            foreach (var item in list)
            {
                Console.WriteLine($"Character : { item.Character }, Count : { item.Count }");
            }

            Console.ReadLine();
        }

        public static List<char> CreateLinq(string word)
        {
            var list = from char c in word
                       orderby c descending
                       select c;
            
            return list.ToList<char>();
        }

        public static List<CharacterCount> CreateLinq2(string word)
        {
            var list = from char c in word
                       orderby word.Count(x => x == c) descending, c ascending
                       select new CharacterCount
                       {
                           Character = c,
                           Count = word.Count(x => x == c)
                       };

            return list.GroupBy(x => x.Character).Select(y => y.FirstOrDefault()).ToList<CharacterCount>();
        }

        public static int charCounter(char c, string word)
        {            
            return word.Count(x => x == c);
        }
        
    }

    public class CharacterCount
    {
        public char Character { get; set; }
        public int Count { get; set; }
    }
}
