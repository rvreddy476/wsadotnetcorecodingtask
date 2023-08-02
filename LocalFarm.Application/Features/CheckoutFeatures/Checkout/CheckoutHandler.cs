using AutoMapper;
using LocalFarm.Application.Constants;
using LocalFarm.Application.POCO;
using LocalFarm.Application.Repositories;
using LocalFarm.Domain.Common;
using MediatR;
using System.Collections.Generic;

namespace LocalFarm.Application.Features.CheckoutFeatures.Checkout
{
    public class CheckoutHandler : IRequestHandler<CheckoutRequest, List<CheckoutResponse>>
    {
        private readonly IDiscountRepository _discountRepository;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private List<CheckoutResponse> responses;
       
        public CheckoutHandler(IDiscountRepository discountRepository,
            IProductRepository productRepository,
            IMapper mapper)
        {
            _discountRepository = discountRepository;
            _productRepository = productRepository;
            _mapper = mapper;
            responses = new();           
        }
        public async Task<List<CheckoutResponse>> Handle(CheckoutRequest request, CancellationToken cancellationToken)
        {
            var discountDetails = await _discountRepository.GetAllDiscountDetails(cancellationToken);
            CheckoutResponse checkoutResponse = null;
            DiscountDetail discountDetail = null;
            var result = _mapper.Map<List<CheckoutResponse>>(request.CartProducts);
            
            foreach (var item in result)
            {
                checkoutResponse = null;
                //Calculate discount
                discountDetail = discountDetails?.FirstOrDefault(x => x.ProductId == item.ProductId && item.Quantity >= x.QuantityThreshold);

                if (discountDetail != null)
                {
                    switch (discountDetail.Discount.DiscountCode.ToUpper())
                    {
                        case Discount_Types.BOGO:
                            await ApplyBOGODiscount(discountDetail, item);
                            break;
                        case Discount_Types.APPL:
                            await ApplyAPPLDiscount(discountDetail, item);
                            break;
                        case Discount_Types.CHMK:
                            checkoutResponse = result.Where(x => x.ProductId == discountDetail.DiscountedProductID).FirstOrDefault();
                            if (checkoutResponse != null)
                            {
                                item.IsDiscountApplied = false;
                                item.TotalPrice = item.Quantity * item.Price;                               
                                item.Discount = 0;
                                responses.Add(item);
                                await ApplyCHMKDiscount(discountDetail, checkoutResponse);
                            }
                            break;
                        case Discount_Types.APOM:
                            checkoutResponse = result.Where(x => x.ProductId == discountDetail.DiscountedProductID).FirstOrDefault();
                            if (result.Any(x => x.ProductId == discountDetail.DiscountedProductID))
                            {
                                item.IsDiscountApplied = false;
                                item.TotalPrice = item.Quantity * item.Price;                                
                                item.Discount = 0;
                                responses.Add(item);
                                await ApplyAPOMDiscount(discountDetail, checkoutResponse);

                            };
                            break;

                        default:
                            if (responses.IndexOf(item) < 0)
                            {
                                item.IsDiscountApplied = false;
                                item.TotalPrice = item.Quantity * item.Price;
                                item.Discount = 0;
                                responses.Add(item);
                            }
                            break;
                    }
                }

                if (responses.IndexOf(item) < 0)
                {
                    item.IsDiscountApplied = false;
                    item.TotalPrice = item.Quantity * item.Price;
                    item.Discount = 0;
                    responses.Add(item);
                }
            }

            responses = responses.GroupBy(x => x.ProductId).Select(x => x.OrderByDescending(x => x.Discount).FirstOrDefault()).ToList();
           
            return responses;
        }

        private async Task ApplyAPOMDiscount(DiscountDetail discountDetail, CheckoutResponse item)
        {
            CheckoutResponse checkoutResponse = new CheckoutResponse();
            checkoutResponse = item;
            checkoutResponse.Discount = (discountDetail.DiscountValue * checkoutResponse.Price) / 100;
            checkoutResponse.TotalPrice = checkoutResponse.Quantity * checkoutResponse.Price;
            checkoutResponse.DiscountDescription = $"Offer Applied : {discountDetail.Discount.Description}.";
            checkoutResponse.IsDiscountApplied = true;
            responses.Add(checkoutResponse);
            await Task.CompletedTask.ConfigureAwait(false);

        }

        private async Task ApplyCHMKDiscount(DiscountDetail discountDetail, CheckoutResponse checkoutResponse)
        {
            checkoutResponse.TotalPrice = checkoutResponse.Quantity * checkoutResponse.Price;
            checkoutResponse.IsDiscountApplied = true;
            checkoutResponse.Discount = discountDetail.DiscountType.Type == Application_Constants.Discount_Percentage ?
                (discountDetail.DiscountValue * (checkoutResponse.Price * discountDetail.Limit)) / 100 : checkoutResponse.TotalPrice - discountDetail.DiscountValue;
            checkoutResponse.DiscountDescription = $"Offer Applied : {discountDetail.Discount.Description}.";            
            responses.Add(checkoutResponse);           
            await Task.CompletedTask.ConfigureAwait(false);
        }       
        private async Task ApplyAPPLDiscount(DiscountDetail discountDetail, CheckoutResponse item)
        {
            CheckoutResponse checkoutResponse = new CheckoutResponse();
            checkoutResponse = item;
            checkoutResponse.TotalPrice = checkoutResponse.Quantity * checkoutResponse.Price;
            checkoutResponse.IsDiscountApplied = true;
            checkoutResponse.Discount = checkoutResponse.Quantity * discountDetail.DiscountValue;
            checkoutResponse.DiscountDescription = $"Offer Applied : {discountDetail.Discount.Description}.";
            responses.Add(checkoutResponse);
            await Task.CompletedTask.ConfigureAwait(false);
        }

        private async Task ApplyBOGODiscount(DiscountDetail discountDetail, CheckoutResponse checkoutResponse)
        {
            checkoutResponse.TotalPrice = checkoutResponse.Quantity * checkoutResponse.Price;
            checkoutResponse.IsDiscountApplied = true;
            checkoutResponse.Discount = (discountDetail.IsUnLimited ?? false) ? ((checkoutResponse.Quantity > 2 && checkoutResponse.Quantity % 2 == 0) ?
            (checkoutResponse.Quantity * checkoutResponse.Price) / 2 : ((checkoutResponse.Quantity / 2) * checkoutResponse.Price))
            : (discountDetail.Limit > 2 ? (discountDetail.Limit * checkoutResponse.Price) / 2 : 0);
            checkoutResponse.DiscountDescription = $"Offer Applied : {discountDetail.Discount.Description}.";
            responses.Add(checkoutResponse);
            await Task.CompletedTask.ConfigureAwait(false);
        }

    }
}
