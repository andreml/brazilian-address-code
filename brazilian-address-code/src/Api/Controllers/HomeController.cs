using App.Service;
using Microsoft.AspNetCore.Mvc;
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
            AddressService _service = new AddressService();
            var result = await _service.GetAddressByZipCode(zipCode);

            return StatusCode(200, result);
        }
    }
}
