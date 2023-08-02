using LocalFarm.Application.Features.ProductFeatures.GetAllProduct;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalFarm.Application.Features.DiscountFeatures.GetAllDiscount
{
    public sealed record GetAllDiscountDetailRequest:IRequest<List<GetAllDiscountDetailResponse>>;   

}
