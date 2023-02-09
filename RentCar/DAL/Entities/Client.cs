using DAL.Enumerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Client : BaseEntity
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string PersonalNumber { get; set; }
        public string CRNumber { get; set; }
        public string CRName { get; set; }
        public string CRExpiration { get; set; }
        public int CRCCVNumber { get; set; }
        public double CreditLimit { get; set; }
        public PersonType PersonType { get; set; }
    }
}
