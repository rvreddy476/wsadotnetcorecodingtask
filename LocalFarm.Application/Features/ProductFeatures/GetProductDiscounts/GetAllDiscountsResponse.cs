using LocalFarm.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalFarm.Application.Features.ProductFeatures.GetProductDiscounts
{
    public class GetAllDiscountsResponse
    {
        public int Id { get;set; }
        public int ProductId { get; set; }       
        public int DiscountId { get; set; }       
        public int DiscountedProductID { get; set; }
        public string DiscountType { get; set; }        
        public double DiscountValue { get; set; }
        public int QuantityThreshold { get; set; }
        public bool? IsUnLimited { get; set; }
        public int? Limit { get; set; }
    }
}
