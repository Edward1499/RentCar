﻿using DAL.Enumerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Employee : BaseEntity
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string PersonalNumber { get; set; }
        public BatchWork BatchWork { get; set; }
        public int CommissionPercentage { get; set; }
        public DateTime StartDate { get; set; }
    }
}
