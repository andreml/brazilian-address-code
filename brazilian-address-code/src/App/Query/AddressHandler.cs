using Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace App.Query
{
    public class AddressHandler : IRequestHandler<AddressRequest, AddressResponse>
    {
        readonly IAddressService _service;
        public AddressHandler(IAddressService service) { _service = service; }
        public async Task<AddressResponse> Handle(AddressRequest request, CancellationToken cancellationToken)
        {
            var response = new AddressResponse()
            {
                Response = await _service.GetAddressByZipCode(request.zipCode)
            };

            return response;
        }
    }
}
