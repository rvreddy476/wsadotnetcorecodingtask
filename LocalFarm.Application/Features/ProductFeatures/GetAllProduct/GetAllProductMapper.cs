using AutoMapper;
using LocalFarm.Domain.Common;

namespace LocalFarm.Application.Features.ProductFeatures.GetAllProduct
{
    public class GetAllProductMapper :Profile
    {
        public GetAllProductMapper()
        { 
            CreateMap<Product,GetAllProductResponse>();
        }
    }
}
