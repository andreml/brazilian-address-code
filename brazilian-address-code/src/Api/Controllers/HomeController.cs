using App.Service;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace brazilian_address_code.Controllers
{
    [ApiController]
    [Route("Address")]
    public class HomeController : Controller
    {
        [HttpGet("{zipCode}")]
        public async Task<IActionResult> Index(string zipCode)
        {
            var valid = new Address();
            valid.zipCode = zipCode;

            if (!valid.IsValid())
            {
                var erro = new ErrorResponse() { Code = (int)HttpStatusCode.BadRequest, Message = "zipCode invalid", Details = "zipCode format accept: 99999999"};
                return BadRequest(erro);
            }

            AddressService _service = new AddressService();
            var result = await _service.GetAddressByZipCode(zipCode);

            return StatusCode(200, result);
        }
    }
}
