using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Core.Entities
{
    public class Employee
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }

        public string City;
        public decimal Salary { get; set; }

    }
}
