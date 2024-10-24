using AutoMapper;
using SuperMarket.Core.Domain.DTO;
using SuperMarket.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using SuperMarket.Core.Entities;

namespace SuperMarket.Core.Service
{
    public class ViaCepService : IViaCepService
    {
        private readonly HttpClient _httpClient;
        private readonly IMapper _mapper;

        public ViaCepService(HttpClient httpClient, IMapper mapper)
        {
            _mapper = mapper;
            _httpClient = httpClient;
        }

        public async Task<AddressResponseDTO> GetAddressByPostalCode(string postalCode)
        {
            var response = await _httpClient.GetAsync($"https://viacep.com.br/ws/{postalCode}/json/");
            response.EnsureSuccessStatusCode();
            var jsonString = await response.Content.ReadAsStringAsync();
            var addressResponse = JsonSerializer.Deserialize<AddressResponseDTO>(jsonString);
            return addressResponse;
        }
    }
}
