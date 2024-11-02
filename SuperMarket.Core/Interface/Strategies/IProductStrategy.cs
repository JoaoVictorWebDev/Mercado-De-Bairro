using SuperMarket.Core.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Core.Interface.Strategies
{
    public interface IProductStrategy
    {
        (bool isAvailable, string errorMessage) IsAvailable(ProductsDTO productsDTO);
    }
}
