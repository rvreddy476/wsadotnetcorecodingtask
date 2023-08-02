using AutoMapper;
using LocalFarm.Application.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalFarm.Application.Features.CheckoutFeatures.Checkout
{
    public class CheckoutMapper:Profile
    {
        public CheckoutMapper()
        {
            CreateMap<CartProduct, CheckoutResponse>()
                .ForMember(dest => dest.ProductId, src => src.MapFrom(x => x.Id));
        }
    }
}
