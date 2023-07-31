using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalFarm.Application.Features.ProductFeatures.GetAllProduct
{
    public class GetAllProductResponse
    {
        public int Id { get;set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public string ProductDescription { get; set; }
        public string ImageUrl { get; set; }
    }
}
