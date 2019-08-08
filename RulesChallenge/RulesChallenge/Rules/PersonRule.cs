using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RulesChallenge
{
    class PersonRule : IChallengeRules
    {
        public void PrintOutStatements(IChallengeModel p)
        {
            Console.WriteLine("FirstName : {0}, LastName : {1}, PostalCode : {2}", p.FirstName, p.LastName, p.PostalCode);
            char[] NameCharArray = p.FirstName.ToCharArray();
            char[] PostalCodeCharArray = p.PostalCode.ToString().ToCharArray();

            if (p.LastName == "Corey" && p.FirstName != "Tim")
            {
                Console.WriteLine("Possibly related to Tim Corey");
            }
            if (NameCharArray[0] == 'T' &&
                    NameCharArray[1] == 'C')
            {
                Console.WriteLine("Same initials as Tim Corey");
            }
            if (PostalCodeCharArray[0] == '1' &&
                    PostalCodeCharArray[1] == '8')
            {
                Console.WriteLine("In the same general area as Tim");
            }
        }
    }
}
