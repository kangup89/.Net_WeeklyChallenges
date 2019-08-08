using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RulesChallenge
{
    interface IChallengeModel
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        string CompanyName { get; set; }

        string PostalCode { get; set; }

        IChallengeRules Rules { get; set; }
    }
}
