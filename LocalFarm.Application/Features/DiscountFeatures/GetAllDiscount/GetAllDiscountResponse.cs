using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalFarm.Application.Features.DiscountFeatures.GetAllDiscount
{
    public class GetAllDiscountResponse
    {
        public int Id { get; set; }
        public string DiscountCode { get; set; }
        public string DiscountName { get; set; }
        public string Description { get; set; }
    }
}
