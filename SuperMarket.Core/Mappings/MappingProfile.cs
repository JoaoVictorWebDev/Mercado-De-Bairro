using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using SuperMarket.Core.Domain.DTO;
using SuperMarket.Core.Entities;

namespace SuperMarket.Core.Mappings
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductsDTO, Products>();
            CreateMap<Products, ProductsDTO>();

            CreateMap<Employee, EmployeeDTO>();
            CreateMap<EmployeeDTO, Employee >();
        }
    }
}
