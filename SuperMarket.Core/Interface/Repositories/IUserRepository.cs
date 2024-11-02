using SuperMarket.Core.Domain.DTO;
using SuperMarket.Core.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Core.Interface.Repositories
{
    public interface IUserRepository
    {
        Task<UserDTO> RegisterUser(UserDTO userDTO);
        Task<UserDTO> RegisterUser(UserDTO userDTO);

    }
}
