using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RulesChallenge
{
    class Person : IChallengeModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; } = null;
        public string PostalCode { get; set; }

        public IChallengeRules Rules { get; set; } = new PersonRule();        
    }
}
