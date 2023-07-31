namespace LocalFarm.Domain.Common
{
    public class DiscountTypeId:BaseEntity
    {
        public string DiscountCode { get; set; }
        public string DiscountName { get; set; }
        public string Description { get; set;}
        public ICollection<DiscountDetail> DiscountDetails { get; }
    }
}
