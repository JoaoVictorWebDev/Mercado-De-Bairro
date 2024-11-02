using SuperMarket.Core.Domain.DTO;
using SuperMarket.Core.Interface.Strategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Core.Strategies
{
    public class ExpirationDateAvailableStrategy : IProductStrategy
    {
        public (bool isAvailable, string errorMessage) IsAvailable(ProductsDTO productsDTO)
        {
            if (productsDTO.ExpirationDate <= DateTime.Now)
            {
                return (false, "Product is out of expiration date.");
            }
            return (true, null);
        }
}   }
