using SuperMarket.Core.Domain.DTO;
using SuperMarket.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Core.Strategies
{
    public class StockAvaliableStrategy : IProductStrategy
    {
        public bool IsAvailable(ProductsDTO productsDTO)
        {
            return productsDTO.Quantity > 0;
        }
    }
}
