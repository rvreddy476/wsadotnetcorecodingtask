using LocalFarm.Application.POCO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalFarm.Application.Features.CheckoutFeatures.Checkout
{
    public sealed record CheckoutRequest(List<CartProduct> CartProducts) :IRequest<List<CheckoutResponse>>;
}
