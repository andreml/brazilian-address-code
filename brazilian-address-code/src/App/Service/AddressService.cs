using Domain.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace App.Service
{
    public class AddressService
    {
        HttpClient _;
        public AddressService()
        {
            _ = new HttpClient();
        }

        public async Task<AddressResponse> GetAddressByZipCode(string code)
        {
            var url = $"https://viacep.com.br/ws/{code}/json/".Replace("-","");
            var response = await _.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var validResult = response.Content.ReadAsStringAsync().Result;

                if (validResult.Contains("true")) return null;
                
                var result = JsonConvert.DeserializeObject<AddressResponse>(validResult);
                return result;
            }
            else
            {
                throw new Exception("Error");
            }
        }
    }
}
