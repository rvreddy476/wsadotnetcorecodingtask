using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalFarm.Application.Features.CheckoutFeatures.Checkout
{
    public class CheckoutResponse
    {
        public int ProductId { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public string ProductDescription { get; set; }
        public string ImageUrl { get; set; }
        public int Quantity { get; set; }
        public double? TotalPrice { get; set; }
        public double? Discount { get; set; }
        public bool? IsDiscountApplied { get; set; }
        public bool? IsFreeProduct { get; set; }
        public string? DiscountDescription { get; set; }
    }
}
