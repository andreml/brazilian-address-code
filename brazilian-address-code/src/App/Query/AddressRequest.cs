using MediatR;
namespace App.Query
{
    public class AddressRequest : IRequest<AddressResponse>
    {
        public string zipCode { get; set; }
    }
}
