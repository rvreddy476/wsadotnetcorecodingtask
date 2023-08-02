using AutoMapper;
using LocalFarm.Domain.Common;

namespace LocalFarm.Application.Features.DiscountFeatures.GetAllDiscount
{
    public class GetAllDiscountDetailMapper:Profile
    {
        public GetAllDiscountDetailMapper()
        {
            CreateMap<DiscountDetail, GetAllDiscountDetailResponse>()
              .ForMember(dest => dest.DiscountDescrption, src => src.MapFrom(x => x.Discount.Description))
              .ForMember(dest => dest.DiscountCode, src => src.MapFrom(x => x.Discount.DiscountCode))
              .ForMember(dest => dest.DiscountType, src => src.MapFrom(x => x.DiscountType.Type));
        }
    }
}
