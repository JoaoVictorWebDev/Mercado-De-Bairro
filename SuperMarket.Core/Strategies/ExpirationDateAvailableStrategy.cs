using SuperMarket.Core.Domain.DTO;
using SuperMarket.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Core.Strategies
{
    public class ExpirationDateAvailableStrategy:IProductStrategy
    {
        public bool IsAvailable(ProductsDTO products)
        {
            return products.ExpirationDate > DateTime.Now;
        }
    }
}
