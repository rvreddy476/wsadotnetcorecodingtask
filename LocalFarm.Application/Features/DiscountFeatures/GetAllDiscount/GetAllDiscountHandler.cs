using AutoMapper;
using LocalFarm.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalFarm.Application.Features.DiscountFeatures.GetAllDiscount
{
    public class GetAllDiscountHandler : IRequestHandler<GetAllDiscountRequest, List<GetAllDiscountResponse>>
    {
        private readonly IDiscountRepository _discountRepository;
        private readonly IMapper _mapper;

        public GetAllDiscountHandler(IDiscountRepository discountRepository, IMapper mapper)
        {
            _discountRepository = discountRepository;
            _mapper = mapper;
        }
        public async Task<List<GetAllDiscountResponse>> Handle(GetAllDiscountRequest request, CancellationToken cancellationToken)
        {
            var discounts =await _discountRepository.GetAllDiscount(cancellationToken).ConfigureAwait(false);
            return _mapper.Map<List<GetAllDiscountResponse>>(discounts);
        }
    }
}
