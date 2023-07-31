using MediatR;

namespace LocalFarm.Application.Features.ProductFeatures.GetAllProduct
{
    public sealed record GetAllProductRequest:IRequest<List<GetAllProductResponse>>;
    
}
