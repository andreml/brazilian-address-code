using Domain.Entities;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IAddressService
    {
        Task<AddressModelResponse> GetAddressByZipCode(string code);
    }
}
