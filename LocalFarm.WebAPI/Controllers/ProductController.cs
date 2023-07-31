using LocalFarm.Application.Features.ProductFeatures.GetAllProduct;
using LocalFarm.Application.Features.ProductFeatures.GetProductDiscounts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LocalFarm.WebAPI.Controllers
{   
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductController(IMediator mediator)=> _mediator = mediator;


        [HttpGet]
        [Route("/products")]
        public  async Task<ActionResult<List<GetAllProductResponse>>> GetAllProducts()
        {
            var response = await _mediator.Send(new GetAllProductRequest());
            return Ok(response);
        }
        [HttpGet]
        [Route("/productdiscounts")]
        public async Task<ActionResult<List<GetAllDiscountsResponse>>> GetAllProductDiscounts()
        {
            var response = await _mediator.Send(new GetAllDiscountsRequest());
            return Ok(response);
        }
    }
}
