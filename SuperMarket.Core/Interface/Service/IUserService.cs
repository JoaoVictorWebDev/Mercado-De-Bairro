using SuperMarket.Core.Domain.DTO;
using SuperMarket.Core.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Core.Interface.Service
{
    public interface IUserService
    {
        Task<ServiceResult<UserDTO>> RegisterUserAsync(UserDTO userDTO);
    }
}
