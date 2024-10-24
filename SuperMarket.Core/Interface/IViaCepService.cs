﻿using SuperMarket.Core.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Core.Interface
{
    public interface IViaCepService
    {
        Task<AddressResponseDTO> GetAddressByPostalCode(string postalCode);
    }
}
