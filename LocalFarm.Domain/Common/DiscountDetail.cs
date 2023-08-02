using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalFarm.Domain.Common
{
    public class DiscountDetail:BaseEntity
    {
        public int? ProductId { get; set; }
        public Product Product { get; set; }
        public int DiscountId { get; set; }
        public Discount Discount { get; set; }
        public int DiscountedProductID { get; set; }
        public int? DiscountTypeId { get; set; }
        public DiscountType DiscountType { get; set; }
        public double DiscountValue { get; set; }
        public int QuantityThreshold { get; set; } 
        public bool? IsUnLimited { get; set; }
        public int? Limit { get; set; } 
        public bool? IsApplicableForEachProduct { get; set; }
        public bool? IsActive { get; set; }
        
    
    }
}
