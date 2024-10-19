using SuperMarket.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Core.Domain.DTO
{
    public class ProductsDTO
    {
        [Key]
        public long ProductID;
        [StringLength(300)]
        public string ProductName { get; set; }
        public DateTime ExpirationDate { get; set; }
        [StringLength(250)]
        public string Supplier { get; set; }
        public ProductCategoryEnum ProductCategory { get; set; }
    }
}
