using AutoMapper;
using LocalFarm.Domain.Common;
namespace LocalFarm.Application.Features.DiscountFeatures.GetAllDiscount
{
    public class GetAllDiscountMapper:Profile
    {
        public GetAllDiscountMapper()
        {
            CreateMap<Discount, GetAllDiscountResponse>();
        }
    }
}
