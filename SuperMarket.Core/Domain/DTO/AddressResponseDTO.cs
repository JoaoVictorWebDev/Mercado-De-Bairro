using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Core.Domain.DTO
{
    public class AddressResponseDTO
    {
        [MaxLength(255)]
        public string PostalCode { get; set; }
        [MaxLength(255)]
        public string PublicPlace { get; set; }
        [MaxLength(255)]
        public string Complement { get; set; }
        [MaxLength(2)]
        public string uf { get; set; }
        [MaxLength(255)]
        public string state { get; set; }
        [MaxLength(255)]
        public string region { get; set; }
        [MaxLength(2)]
        public string ddd { get; set; }
    }
}
