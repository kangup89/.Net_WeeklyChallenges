using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateTimeChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime currentTime = DateTime.Now;
            Console.WriteLine("CurrentTime : {0}", currentTime);
            
            long currentMilli = new DateTimeOffset(DateTime.Now).ToUnixTimeMilliseconds();
            Console.WriteLine("CurrentTime millisecond : {0}", currentMilli);

            bool quit = false;

            do
            {
                Console.Write("Give command(Date or Time): ");
                String command = Console.ReadLine();

                switch (command.ToLower())
                {
                    case "date":
                        calcDate(currentMilli);
                        break;
                    case "time":
                        calcTime(currentTime);
                        break;
                    case "quit":
                        quit = true;
                        break;
                    default:
                        break;
                } 
            } while (!quit);

            Console.ReadLine();
        }

        private static void calcDate(long currentMilli)
        {
            Console.Write("Give a format: ");
            string format = Console.ReadLine();

            Console.Write("Give a date : ");
            string date = Console.ReadLine();

            CultureInfo provider = CultureInfo.InvariantCulture;

            DateTime givenTime = DateTime.ParseExact(date, format, provider);
            //Console.WriteLine("Date : {0}", givenTime.ToString());

            long givenMilli = new DateTimeOffset(givenTime).ToUnixTimeMilliseconds();
            //Console.WriteLine("Date millisecond : {0}", givenMilli);

            if (currentMilli >= givenMilli)
            {
                long diffMilli = currentMilli - givenMilli;
                //Console.WriteLine("diffMilli : {0}", diffMilli);

                //Console.WriteLine(new DateTime(default));

                DateTime diffTime = (new DateTime(default)).AddMilliseconds((double)diffMilli);
                Console.WriteLine("{0} years {1} months {2} days ago", diffTime.Year - 1, diffTime.Month - 1, diffTime.Day - 1); 
            }
            else
            {
                long diffMilli =  givenMilli - currentMilli;

                DateTime diffTime = (new DateTime(default)).AddMilliseconds((double)diffMilli);
                Console.WriteLine("{0} years {1} months {2} days later", diffTime.Year - 1, diffTime.Month - 1, diffTime.Day - 1);
            }
        }

        private static bool calcTime(DateTime currentTime)
        {
            int currentHours = currentTime.Hour;
            int currentMinutes = currentTime.Minute;

            Console.Write("Give a format (12 or 24) :");
            int format = int.Parse(Console.ReadLine());

            Console.Write("Give a time : ");
            string[] givenTime = Console.ReadLine().Split(':');

            int givenHours = int.Parse(givenTime[0]);
            int givenMinutes = int.Parse(givenTime[1]);

            if (format == 24)
            {
                if (givenHours > 24 || givenMinutes > 60)
                {
                    Console.WriteLine("Invalid numbers of hours and minutes");
                    return false;
                }
            }
            else if (format == 12)
            {
                if (givenHours > 12 || givenMinutes > 60) 
                {
                    Console.WriteLine("Invalid numbers of hours and minutes");
                    return false;
                }
                else if (currentHours > 12)
                {
                    currentHours = currentHours - 12;
                }
            }
           
            Console.WriteLine("currentHours : {0}, currentMinutes : {1}", currentHours, currentMinutes);
            Console.WriteLine("givenHours : {0}, givenMinnutes : {1}", givenTime[0], givenTime[1]);

            if (currentHours >= givenHours)
            {
                if (currentMinutes >= givenMinutes)
                {
                    Console.WriteLine("{0} hours {1} minutes ago", currentHours - givenHours, currentMinutes - givenMinutes);
                }
                else
                {
                    Console.WriteLine("{0} hours {1} minutes ago", (currentHours - givenHours) - 1, 60 - (givenMinutes - currentMinutes));
                }
            }
            else
            {
                if (givenMinutes >= currentMinutes)
                {
                    Console.WriteLine("{0} hours {1} minutes later", givenHours - currentHours, givenMinutes - currentMinutes);
                }
                else
                {
                    Console.WriteLine("{0} hours {1} minutes later", (givenHours - currentHours) - 1, 60 - (currentMinutes - givenMinutes));
                }
            }

            return true;
        }

    }
}
