using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            List<PersonModel> peopleList = getPeopleList();

            foreach(PersonModel p in peopleList)
            {
                Console.WriteLine($"Hello {p.FirstName} {p.LastName}");
            }

            Console.ReadLine();
        }   

        public static List<PersonModel> getPeopleList()
        {
            List<PersonModel> output = new List<PersonModel>();

            output.Add(new PersonModel{ FirstName = "aaa", LastName = "aaa" });
            output.Add(new PersonModel{ FirstName = "bbb", LastName = "bbb" });
            output.Add(new PersonModel{ FirstName = "ccc", LastName = "ccc" });
            output.Add(new PersonModel{ FirstName = "ddd", LastName = "ddd" });
            output.Add(new PersonModel{ FirstName = "eee", LastName = "eee" });

            return output;
        }
    }
}
