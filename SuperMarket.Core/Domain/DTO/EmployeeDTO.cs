using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMarket.Core.Validators;
namespace SuperMarket.Core.Domain.DTO
{
    public class EmployeeDTO
    {
        [Key]
        public long EmployeeId { get; set; }

        [MaxLength(255)]
        public string Name { get; set; }

        public string Role { get; set; }

        [MaxLength(255)]
        public string City { get; set; } 

        public decimal Salary { get; set; }

        [MaxLength(11)]
        [CPFValidator]  
        public string CPF { get; set; }

        [MaxLength(8)]
        public string PostalCode { get; set; }

        [MaxLength(255)]
        public string PublicPlace { get; set; }

        [MaxLength(255)]
        public string Complement { get; set; }

        [MaxLength(2)]
        public string Uf { get; set; }  

        [MaxLength(255)]
        public string State { get; set; }  

        [MaxLength(255)]
        public string Region { get; set; }  

        [MaxLength(2)]
        public string Ddd { get; set; }  
    }
}
