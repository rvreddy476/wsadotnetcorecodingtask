namespace LocalFarm.Application.Features.DiscountFeatures.GetAllDiscount
{
    public class GetAllDiscountDetailResponse
    {
        public int Id { get; set; }
        public int? ProductId { get; set; }        
        public int DiscountId { get; set; }       
        public int? DiscountedProductID { get; set; }
        public string? DiscountType { get; set; }
        public double? DiscountValue { get; set; }
        public int QuantityThreshold { get; set; }
        public bool? IsUnLimited { get; set; }
        public int? Limit { get; set; }
        public bool? IsApplicableForEachProduct { get; set; }
        public bool? IsActive { get; set; }
        public string? DiscountCode { get; set; }
        public string? DiscountDescrption { get; set; }
    }
}
