using MediatR;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;
using App.Query;
using System;
using Swashbuckle.AspNetCore.Annotations;

namespace brazilian_address_code.Controllers
{
    [ApiController]
    [Route("Address")]
    public class HomeController : Controller
    {
        readonly IMediator mediator;
        public HomeController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet("{zipCode}")]
        [Produces("application/json")]
        [SwaggerResponse((int)HttpStatusCode.OK, "Return Address", typeof(AddressModelResponse)]
        [SwaggerResponse((int)HttpStatusCode.NotFound, "Address not found!", typeof(ErrorModelResponse))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, "Invalid zipCode or another error", typeof(ErrorModelResponse))]
        public async Task<IActionResult> Index(string zipCode)
        {
            try
            {
                if (Validator.IsValid(zipCode) is false)
                {
                    var erro = new ErrorModelResponse() { Code = (int)HttpStatusCode.BadRequest, Message = "zipCode invalid", Details = "zipCode format accept: 99999999" };
                    return BadRequest(erro);
                }

                var request = new AddressRequest() { zipCode = zipCode.Trim() };
                var result = await mediator.Send(request);

                if (result.Response is null)
                {
                    var erro = new ErrorModelResponse() { Code = (int)HttpStatusCode.BadRequest, Message = "Not found", Details = "Address not found!" };
                    return NotFound(erro);
                }

                return StatusCode(200, result.Response);
            }
            catch (Exception e)
            {
                var erro = new ErrorModelResponse() { Code = (int)HttpStatusCode.BadRequest, Details = e.Message, Message = e.InnerException.StackTrace };
                return BadRequest(erro);
            }
        }
    }
}
