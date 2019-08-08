using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruckRentalChallenge
{
    class Program
    {
        public static int firstPrice = 5;
        public static int hourPrice = 50;
        public static int firstMinutes = 20;
        public static int closeHour = 20;

        static void Main(string[] args)
        {
            Truck truck = new Truck();
            truck.StartTime = new DateTime(2019, 7, 25, 5, 20, 0);
            truck.EndTime = new DateTime(2019, 7, 28, 20, 0, 0);

            StartCalculation(truck);

            Console.ReadLine();
        }

        public static void StartCalculation(Truck truck)
        {
            truck.RentalPrice += firstPrice;

            if (truck.EndTime.Hour >= closeHour || (truck.EndTime.DayOfYear > truck.StartTime.DayOfYear))
            {
                int startDate = truck.StartTime.DayOfYear;
                int difference = truck.EndTime.DayOfYear - truck.StartTime.DayOfYear;

                int weekday = 0;
                int weekend = 0;

                if (truck.EndTime.Hour >= closeHour)
                {
                    for (int i = 0; i <= difference; i++)
                    {
                        truck.RentalPrice += CheckWeekend(truck.EndTime.AddDays(-i), ref weekday, ref weekend);
                    }
                }
                else
                {
                    for (int i = 1; i <= difference; i++)
                    {
                        truck.RentalPrice += CheckWeekend(truck.EndTime.AddDays(-i), ref weekday, ref weekend);
                    }
                }

                Console.WriteLine($"Weekdays : { weekday }, Weekends : { weekend }");
                Console.WriteLine($"Total price is { truck.RentalPrice }");
            }
            else
            {
                CalculateOneDay(truck);
            }
        }

        public static void CalculateOneDay(Truck truck)
        {
            TimeSpan time = truck.EndTime - truck.StartTime;

            int hour = (int)Math.Truncate(time.TotalHours);
            int minute = (int)Math.Truncate(time.TotalMinutes % 60);
            bool nextHour;

            if (minute >= firstMinutes)
            {
                nextHour = ((minute - firstMinutes) > 10) ? true : false;
            }
            else
            {
                nextHour = false;
            }

            if (hour >= 1)
            {
                truck.RentalPrice += (hour * hourPrice);
            }
            if (nextHour)
            {
                truck.RentalPrice += hourPrice;
            }

            Console.WriteLine("Hours : {0}, Minutes : {1}", hour, minute);
            Console.WriteLine("total price is : {0}", truck.RentalPrice);
        }
       
        public static int CheckWeekend(DateTime date, ref int weekday, ref int weekend)
        {
            if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
            {
                weekend++;
                return 200;
            }
            else
            {
                weekday++;
                return 400;
            }
        }
    }
}
