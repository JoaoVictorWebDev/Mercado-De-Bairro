using SuperMarket.Core.Enums;
using SuperMarket.Core.Handler.CPF;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMarket.Core.Strategies;

namespace SuperMarket.Core.Domain.DTO
{
    public class ProductsDTO
    {
        [Key]
        public long ProductID { get; set; }
        [StringLength(300)]
        public string ProductName { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ExpirationDate { get; set; }
        [StringLength(250)]
        public string Supplier { get; set; }
        public ProductCategoryEnum ProductCategory { get; set; }
        [DataType(DataType.Currency)]
        [Range(0.0, Double.MaxValue)]
        public Double Price { get; set; }
        [MaxLength(1000)]
        public String Description { get; set; }
        public int Quantity { get; set; }
    }
}   
