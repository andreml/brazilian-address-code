using Domain.Entities;
using Domain.Interfaces;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Infraestucture.Service
{
    public class AddressService : IAddressService
    {
        HttpClient _client;
        public AddressService()
        {
            _client = new HttpClient();
        }

        public async Task<AddressModelResponse> GetAddressByZipCode(string code)
        {
            var url = $"https://viacep.com.br/ws/{code}/json/".Replace("-","");
            var response = await _client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var validResult = response.Content.ReadAsStringAsync().Result;

                if (validResult.Contains("true")) return null;
                
                var result = JsonConvert.DeserializeObject<AddressModelResponse>(validResult);
                return result;
            }
            else
            {
                throw new Exception("Error");
            }
        }
    }
}
