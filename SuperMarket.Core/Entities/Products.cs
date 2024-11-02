using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMarket.Core.Domain.DTO;
using SuperMarket.Core.Enums;

namespace SuperMarket.Core.Entities
{
    public class Products
    {
        public long ProductID { get; set; }
        public string ProductName { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Supplier { get; set; }
        public ProductCategoryEnum ProductCategory { get; set; }
        public Double Price { get; set; }
        public String Description { get; set; }
        public int Quantity { get; set; }
    }
}

