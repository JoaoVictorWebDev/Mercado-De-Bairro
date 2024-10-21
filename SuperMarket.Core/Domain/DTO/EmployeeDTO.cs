using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMarket.Core.Domain.DTO.ComponentModel

namespace SuperMarket.Core.Domain.DTO
{
    public class EmployeeDTO
    {
        [Key]
        public long Id { get; set; }
        [MaxLength(255)]
        public string Name { get; set; }
        public string Role { get; set; }
        [MaxLength(255)]
        public string City;
        public decimal Salary { get; set; }
        [MaxLength(11)]
        [CPFValidaton]
        public string CPF { get; set; }
        [MaxLength(8)]
        public string PostalCode { get; set }
    }
}
