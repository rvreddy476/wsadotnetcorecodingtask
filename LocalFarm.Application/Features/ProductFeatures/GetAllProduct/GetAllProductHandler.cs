using AutoMapper;
using LocalFarm.Application.Repositories;
using MediatR;
using MediatR.Pipeline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalFarm.Application.Features.ProductFeatures.GetAllProduct
{
    public class GetAllProductHandler : IRequestHandler<GetAllProductRequest, List<GetAllProductResponse>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetAllProductHandler(IProductRepository productRepository,IMapper mapper)
        {
            _productRepository= productRepository;
            _mapper= mapper;
        }
        public async Task<List<GetAllProductResponse>> Handle(GetAllProductRequest request, CancellationToken cancellationToken)
        {
            var products =await _productRepository.GetAllProducts(cancellationToken);
            return _mapper.Map<List<GetAllProductResponse>>(products);
        }
    }
}
