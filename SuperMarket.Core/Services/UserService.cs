using AutoMapper;
using SuperMarket.Core.Domain.DTO;
using SuperMarket.Core.Entities;
using SuperMarket.Core.Interface.Repositories;
using SuperMarket.Core.Interface.Service;
using SuperMarket.Core.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Core.Services
{
    public class UserService:IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResult<UserDTO>> RegisterUserAsync(UserDTO userDTO)
        {
            try
            {   if(userDTO == null)
                {
                    ServiceResult<UserDTO>.Error("User is Empty");
                }
                var register = await _userRepository.RegisterUser(userDTO);
                var registredUserToDTO = _mapper.Map<UserDTO>(register);
                return ServiceResult<UserDTO>.Success(registredUserToDTO);
            }
            catch (Exception ex)
            {
               return ServiceResult<UserDTO>.Exception(ex);
            }
        }
    }
}
