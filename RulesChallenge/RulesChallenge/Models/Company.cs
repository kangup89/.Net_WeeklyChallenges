using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RulesChallenge
{
    class Company : IChallengeModel
    {
        public string CompanyName { get; set; }
        public string PostalCode { get; set; }

        public IChallengeRules Rules { get; set; } = new CompanyRule();

        public string FirstName { get; set; } = null;
        public string LastName { get; set; } = null;
    }
}
