using LocalFarm.Application.Features.CheckoutFeatures.Checkout;
using LocalFarm.Application.POCO;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LocalFarm.WebAPI.Controllers
{    
    [ApiController]
    public class CheckOutController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CheckOutController(IMediator mediator) => _mediator = mediator;

        [HttpPost]
        [Route("/checkout")]
        public async Task<ActionResult<List<CheckoutResponse>>> Checkout(List<CartProduct> cartProduct)
        {
            var resppnse =await _mediator.Send(new CheckoutRequest(cartProduct));           
            return Ok(resppnse);
        }
    }
}
