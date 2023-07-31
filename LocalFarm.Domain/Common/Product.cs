using System.Diagnostics;

namespace LocalFarm.Domain.Common
{
    public class Product:BaseEntity
    {
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public double Price {get; set; }
        public string ProductDescription { get; set; }
        public string ImageUrl { get; set; }
        public ICollection<DiscountDetail> DiscountDetails { get; }
    }
}
