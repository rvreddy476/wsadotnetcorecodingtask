using LocalFarm.Application.Features.DiscountFeatures.GetAllDiscount;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LocalFarm.WebAPI.Controllers
{
   
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IMediator _mediator;
        public DiscountController(IMediator mediator) => _mediator = mediator;

        [HttpGet]
        [Route("/discounts")]
        public async Task<ActionResult<List<GetAllDiscountResponse>>> GetAllDiscounts()
        {
            var response = await _mediator.Send(new GetAllDiscountRequest());
            return Ok(response);
        }
        [HttpGet]
        [Route("/discountdetails")]
        public async Task<ActionResult<List<GetAllDiscountDetailResponse>>> GetAllDiscountDetails()
        {
            var response = await _mediator.Send(new GetAllDiscountDetailRequest());
            return Ok(response);
        }
    }
}
