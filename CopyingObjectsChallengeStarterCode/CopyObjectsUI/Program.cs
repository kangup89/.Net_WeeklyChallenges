using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace CopyObjectsUI
{
    class Program
    {
        static void Main(string[] args)
        {
            PersonModel firstPerson = new PersonModel
            {
                FirstName = "Sue",
                LastName = "Storm",
                DateOfBirth = new DateTime(1998, 7, 19),
                Addresses = new List<AddressModel>
                {
                    new AddressModel
                    {
                        StreetAddress = "101 State Street",
                        City = "Salt Lake City",
                        State = "UT",
                        ZipCode = "76321"
                    },
                    new AddressModel
                    {
                        StreetAddress = "842 Lawrence Way",
                        City = "Jupiter",
                        State = "FL",
                        ZipCode = "22558"
                    }
                }
                
            };

            // Creates a second PersonModel object
            PersonModel secondPerson = null;

            // First Way By Using Shallow Clone
            //secondPerson = (PersonModel)firstPerson.Clone();
            //secondPerson.FirstName = "Bob";
            //secondPerson.Addresses = firstPerson.CloneAddresses();
            
            //secondPerson.Addresses[0].StreetAddress = "102 State Street";
            //secondPerson.Addresses[1].StreetAddress = "843 Lawrence Way";

            // Second Way By Usin Deep Clone
            secondPerson = firstPerson.DeepClone();
            secondPerson.FirstName = "Bob";
            secondPerson.Addresses[0].StreetAddress = "102 State Street";
            secondPerson.Addresses[1].StreetAddress = "843 Lawrence Way";

            // Set the value of the secondPerson to be a copy of the firstPerson

            // Update the secondPerson's FirstName to "Bob" 
            // and change the Street Address for each of Bob's addresses
            // to a different value

            // Ensure that the following statements are true
            Console.WriteLine($"{ firstPerson.FirstName } != { secondPerson.FirstName }");
            Console.WriteLine($"{ firstPerson.LastName } == { secondPerson.LastName }");
            Console.WriteLine($"{ firstPerson.DateOfBirth.ToShortDateString() } == { secondPerson.DateOfBirth.ToShortDateString() }");
            Console.WriteLine($"{ firstPerson.Addresses[0].StreetAddress } != { secondPerson.Addresses[0].StreetAddress }");
            Console.WriteLine($"{ firstPerson.Addresses[0].City } == { secondPerson.Addresses[0].City }");
            Console.WriteLine($"{ firstPerson.Addresses[1].StreetAddress } != { secondPerson.Addresses[1].StreetAddress }");
            Console.WriteLine($"{ firstPerson.Addresses[1].City } == { secondPerson.Addresses[1].City }");

            Console.ReadLine();
        }
    }

    public static class Extension
    {
        public static T DeepClone<T>(this T a)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, a);
                stream.Position = 0;
                return (T)formatter.Deserialize(stream);
            }
        }
    }

    [Serializable]
    class PersonModel : ICloneable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public List<AddressModel> Addresses { get; set; } = new List<AddressModel>();

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public List<AddressModel> CloneAddresses()
        {
            List<AddressModel> output = new List<AddressModel>();

            foreach (var address in Addresses)
            {
                output.Add((AddressModel)address.Clone());
            }

            return output;
        }
    }

    [Serializable]
    public class AddressModel : ICloneable
    {
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
