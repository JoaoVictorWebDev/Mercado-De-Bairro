using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using SuperMarket.Core.Domain.DTO;
using SuperMarket.Core.Entities;
using SuperMarket.Core.Interface.Repositories;
using SuperMarket.Data.Contexts;
using System.Security.Cryptography;
namespace SuperMarket.Data.Repositories
{
    public class UserRepository:IUserRepository
    {
        private readonly ApplicationDBContext _context;
        private readonly IMapper _mapper;

        public UserRepository(ApplicationDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task <UserDTO> RegisterUser(UserDTO userDTO)
        {
            var UserEntity = _mapper.Map<User>(userDTO);
            await _context.User.AddAsync(UserEntity);
            await _context.SaveChangesAsync();
            var userDTOResult = _mapper.Map<UserDTO>(UserEntity);
            return userDTOResult;
        }

      
        
    }
}
