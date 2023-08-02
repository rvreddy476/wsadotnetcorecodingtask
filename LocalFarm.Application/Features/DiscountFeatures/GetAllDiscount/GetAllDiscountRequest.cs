using MediatR;

namespace LocalFarm.Application.Features.DiscountFeatures.GetAllDiscount
{
    public sealed record GetAllDiscountRequest:IRequest<List<GetAllDiscountResponse>>;
}
