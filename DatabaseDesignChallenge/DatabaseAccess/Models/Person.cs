using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.Models
{
    class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public int PresentId { get; set; } = 0;
        public List<int> Family = new List<int>();

        public string FullName
        {
            get
            {
                if (PresentId == 0)
                {
                    return $"{ FirstName } { LastName } has no present";
                }
                else
                {
                    return $"{ FirstName } { LastName } has present: { DataAccess.getPresentNameById(PresentId).DisplayName }";
                }
                
            }
        }
    }
}
