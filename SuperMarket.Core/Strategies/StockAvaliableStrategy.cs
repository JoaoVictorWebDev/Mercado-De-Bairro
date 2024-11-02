using SuperMarket.Core.Domain.DTO;
using SuperMarket.Core.Interface.Strategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Core.Strategies
{
    public class StockAvaliableStrategy : IProductStrategy
    {
        public (bool isAvailable, string errorMessage) IsAvailable(ProductsDTO productsDTO)
        {
            if (productsDTO.Quantity > 0)
            {
                return (true, null);
            }
            return (false, "Product is out of stock."); 
        }
    }
}
