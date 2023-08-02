namespace LocalFarm.Application.POCO
{
    public class CartProduct
    {
        public int Id { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public string ProductDescription { get; set; }
        public string ImageUrl { get; set; }
        public int Quantity { get; set; }       
    }
}
