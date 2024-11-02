using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using SuperMarket.Core.Domain.DTO;
using SuperMarket.Core.Entities;
using SuperMarket.Core.Strategies;

namespace SuperMarket.Core.Mappings
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductsDTO, Products>().ReverseMap();
            CreateMap<Products, ProductsDTO>().ReverseMap();
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();
            CreateMap<Employee, EmployeeDTO>().ReverseMap();
            CreateMap<EmployeeDTO, Employee>().ReverseMap();
        }
    }
}
