using AutoMapper;
using LocalFarm.Application.Repositories;
using MediatR;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalFarm.Application.Features.DiscountFeatures.GetAllDiscount
{
    public class GetAllDiscountDetailHandler : IRequestHandler<GetAllDiscountDetailRequest, List<GetAllDiscountDetailResponse>>
    {
        private readonly IDiscountRepository _discountRepository;
        private readonly IMapper _mapper;

        public GetAllDiscountDetailHandler(IDiscountRepository discountRepository, IMapper mapper)
        {
            _discountRepository = discountRepository;
            _mapper = mapper;
        }
        public async Task<List<GetAllDiscountDetailResponse>> Handle(GetAllDiscountDetailRequest request, CancellationToken cancellationToken)
        {
            var discountDetails =await _discountRepository.GetAllDiscountDetails(cancellationToken);
            return _mapper.Map<List<GetAllDiscountDetailResponse>>(discountDetails);
        }
    }
}
