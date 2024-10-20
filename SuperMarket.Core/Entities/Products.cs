using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMarket.Core.Enums;

namespace SuperMarket.Core.Entities
{
    public class Products
    {
        [Key]
        public long ProductID { get; set; }
        [MaxLength(500)]
        public string ProductName { get; set; }
        public DateTime ExpirationDate { get; set; }
        [MaxLength (500)]
        public string Supplier { get; set; }
        public ProductCategoryEnum ProductCategory { get; set; }
    }
}
