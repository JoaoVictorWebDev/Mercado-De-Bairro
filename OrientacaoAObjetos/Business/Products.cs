using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMarket.Business.ProductEnum;

namespace SuperMarket.Business
{
    public class Products
    {
        private string productName { get; set; }
        private double price { get; set; }
        private DateTime ExpirationDate { get; set; }

        private ProductsEnum productsEnum;
        private string category { get; set; }
        private int stockQuantity { get; set; }
        private bool isPerishable { get; set; }
        private string supplierName { get; set; }
        private string ProductCode { get; set; }
        private double discount { get; set; }
        private double Weight { get; set; }
        private string Brand { get; set; }

        public Products(string productName, double price, DateTime expirationDate, ProductsEnum productsEnum, string category, int stockQuantity, bool isPerishable, string supplierName, string productCode, double discount, double weight, string brand)
        {
            this.productName = productName;
            this.price = price;
            ExpirationDate = expirationDate;
            this.productsEnum = productsEnum;
            this.category = category;
            this.stockQuantity = stockQuantity;
            this.isPerishable = isPerishable;
            this.supplierName = supplierName;
            ProductCode = productCode;
            this.discount = discount;
            Weight = weight;
            Brand = brand;
        }

        public Products()
        {
            
        }

        public double GetFinalPrice()
        {
            return price - (price * discount / 100);
        }

        public void isExpired()
        {
            if(DateTime.Now > ExpirationDate)
            {
                Console.WriteLine("Produto Expirado");
            } 
        }

        public void addStock(int quantity)
        {
            stockQuantity += quantity;
        }

        public void reduceStock(int quantity)
        {
            if(stockQuantity >= quantity)
            {
                stockQuantity -= quantity;
            }
            else
            {
                Console.WriteLine("No enough products in Stock!");
            }
            
        }

        public void registerProduct()
        {

        }

    }
}
