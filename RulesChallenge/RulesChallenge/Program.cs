using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RulesChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            IChallengeModel model1 = new Person() { FirstName = "Tom", LastName = "Corey", PostalCode = "1880" };
            ApplyRules(model1);

            IChallengeModel model2 = new Company() { CompanyName = "IAmTimCorey", PostalCode = "0809" };
            ApplyRules(model2);

            Console.ReadLine();
        }

        public static void ApplyRules(IChallengeModel m)
        {
            m.Rules.PrintOutStatements(m);

            Console.WriteLine();
        }

        
    }
}
