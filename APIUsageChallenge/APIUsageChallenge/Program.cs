using APIUsageChallenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace APIUsageChallenge
{
    class Program
    {
        protected static List<Person> people = new List<Person>();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Give a ID number: ");

                int n;
                if (int.TryParse(Console.ReadLine(), out n))
                {
                    GetPerson(n);
                }
                else
                {
                    Console.WriteLine("Given value is not a number");
                }

                Console.WriteLine();
            }
        }

        public static void GetPerson(int n)
        {
            Person p = people.Where(x => (x.Id == n)).FirstOrDefault();

            if (p == null)
            {
                Console.WriteLine("---Get data from WebApi---");
                p = GetPersonFromWeb(n);
            }
            else
            {
                Console.WriteLine("---Get data from Cache---");
            }

            DisplayPerson(p);
        }

        public static Person GetPersonFromWeb(int n)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://swapi.co/");

            // Json formai Accept header
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync($"api/people/{n}").Result;
            if (response.IsSuccessStatusCode)
            {
                //Get lists of all people
                //var people = response.Content.ReadAsAsync<IEnumerable<Person>>().Result;
                //foreach (var p in people)
                //{
                //    Console.WriteLine("Name: {0}, Gender: {1}, Mass: {2}", p.name, p.gender, p.height);
                //}

                //Get information about one person
                var p = response.Content.ReadAsAsync<Person>().Result;
                p.Id = n;
                people.Add(p);

                return p;
            }
            else
            {
                //Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                Console.WriteLine("There is no data with given Id number: {0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                return null;
            }
        }

        public static void DisplayPerson(Person p)
        {
            if (p != null)
            {
                Console.WriteLine("name: {0}", p.FullName);
                Console.WriteLine("height: {0}", p.height);
                Console.WriteLine("mass: {0}", p.mass);
                Console.WriteLine("hair_color: {0}", p.hair_color);
                Console.WriteLine("skin_color: {0}", p.skin_color);
                Console.WriteLine("eye_color: {0}", p.eye_color);
                Console.WriteLine("birth_year: {0}", p.birth_year);
                Console.WriteLine("gender: {0}", p.gender);
                Console.WriteLine("homeworld: {0}", p.homeworld);

                Console.WriteLine("films: [");
                foreach (var item in p.films)
                {
                    Console.WriteLine("   {0}", item);
                }
                Console.WriteLine("],");

                Console.WriteLine("species: [");
                foreach (var item in p.species)
                {
                    Console.WriteLine("   {0}", item);
                }
                Console.WriteLine("],");

                Console.WriteLine("vehicles: [");
                foreach (var item in p.vehicles)
                {
                    Console.WriteLine("   {0}", item);
                }
                Console.WriteLine("],");

                Console.WriteLine("starships: [");
                foreach (var item in p.starships)
                {
                    Console.WriteLine("   {0}", item);
                }
                Console.WriteLine("],");

                Console.WriteLine("created: {0}", p.created);
                Console.WriteLine("edited: {0}", p.edited);
                Console.WriteLine("url: {0}", p.url);
            }
        }
    }
}
