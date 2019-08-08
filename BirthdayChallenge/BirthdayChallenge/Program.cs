using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthdayChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            Person FirstPerson = new Person() { FirstName = "Kang Up", LastName = "Lim", BirthDay = new DateTime(1989, 02, 15) };
            DateTime CurrentTime = DateTime.Now;

            TimeSpan age = CurrentTime - FirstPerson.BirthDay;
            
            Console.WriteLine("age in years = {0}", Math.Round(age.TotalDays/365));
            Console.WriteLine("age in months = {0}", Math.Round((age.TotalDays/30.5)));
            Console.WriteLine("age in days = {0}", Math.Round(age.TotalDays));
            Console.WriteLine();

            DateTime NextBirthDay = new DateTime((CurrentTime.Year + 1), FirstPerson.BirthDay.Month, FirstPerson.BirthDay.Day);

            Console.WriteLine("Next Birthday is {0}", NextBirthDay);

            TimeSpan next = NextBirthDay - CurrentTime;
            Console.WriteLine("Next Birthday is {0} months left", Math.Round(next.TotalDays / 30.5));
            Console.WriteLine("Next Birthday is {0} weekends left", Math.Round(next.TotalDays / 7));


            Console.ReadLine();
        }
    }
}
