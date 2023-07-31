using AutoMapper;
using LocalFarm.Domain.Common;

namespace LocalFarm.Application.Features.ProductFeatures.GetProductDiscounts
{
    public class GetAllDiscountsMapper :Profile
    {
        public GetAllDiscountsMapper()
        {
            CreateMap<DiscountDetail, GetAllDiscountsResponse>()
                .ForMember(dest => dest.DiscountType, sr => sr.MapFrom(x => x.DiscountType.Type));
        }
    }
}
