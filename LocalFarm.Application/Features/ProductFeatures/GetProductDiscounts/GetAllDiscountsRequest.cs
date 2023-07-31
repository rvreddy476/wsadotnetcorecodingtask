using MediatR;

namespace LocalFarm.Application.Features.ProductFeatures.GetProductDiscounts
{
    public record GetAllDiscountsRequest:IRequest<IList<GetAllDiscountsResponse>>;
}
