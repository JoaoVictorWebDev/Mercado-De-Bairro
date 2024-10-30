using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public string City { get; set;}
        public decimal Salary { get; set; }
        public string CPF { get; set; }
        public string PostalCode { get; set; }
        public string PublicPlace { get; set; }
        public string Complement { get; set; }
        public string uf { get; set; }
        public string state { get; set; }
        public string region { get; set; }
        public string ddd { get; set; }
    }
}
