using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Core.Entities
{
    public class AddressResponse
    {
        public string PostalCode { get; set; }
        public string PublicPlace { get; set; }
        public string Complement { get; set; }
        public string uf { get; set; }
        public string state { get; set; }
        public string region { get; set; }
        public string ddd { get; set; }
    }
}
