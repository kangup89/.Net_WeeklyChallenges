using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RulesChallenge
{
    class CompanyRule : IChallengeRules
    {
        public void PrintOutStatements(IChallengeModel c)
        {
            Console.WriteLine("Name : {0}, PostalCode : {1}", c.CompanyName, c.PostalCode);
            char[] NameCharArray = c.CompanyName.ToCharArray();
            char[] PostalCodeCharArray = c.PostalCode.ToString().ToCharArray();

            if (c.CompanyName.Contains("Corey") && c.CompanyName != "IAmTimCorey")
            {
                Console.WriteLine("A company owned by a Corey");
            }
            if (c.CompanyName == "IAmTimCorey")
            {
                Console.WriteLine("Tim’s Company");
            }
            if (PostalCodeCharArray[0] == '0' &&
                    PostalCodeCharArray[1] == '8')
            {
                Console.WriteLine("A company in New Jersey");
            }

            Console.WriteLine();
        }
    }
}
