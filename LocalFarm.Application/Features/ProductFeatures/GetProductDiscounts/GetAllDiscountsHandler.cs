using AutoMapper;
using LocalFarm.Application.Repositories;
using MediatR;

namespace LocalFarm.Application.Features.ProductFeatures.GetProductDiscounts
{
    public class GetAllDiscountsHandler : IRequestHandler<GetAllDiscountsRequest,IList<GetAllDiscountsResponse>>
    {  
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetAllDiscountsHandler(IProductRepository productRepository,IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<IList<GetAllDiscountsResponse>> Handle(GetAllDiscountsRequest request, CancellationToken cancellationToken)
        {
            var discountDetails = await _productRepository.GetAllProductDiscounts(cancellationToken);
            return _mapper.Map<List<GetAllDiscountsResponse>>(discountDetails);
        }
    }
}
