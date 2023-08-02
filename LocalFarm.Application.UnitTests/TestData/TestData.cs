using LocalFarm.Application.POCO;

namespace LocalFarm.Application.UnitTests
{
    public static class TestData
    {
        public static List<CartProduct> GetCartProducts()
        {
            return new List<CartProduct>()
            {
                new CartProduct
                {
                    Id = 3,
                    ProductCode = "CF1",
                    ProductName = "Coffee",
                    Price = 11.23,
                    Quantity = 2
                }
            };
        }
        public static List<DiscountDetail> GetAllDiscountDetails()
        {
            return new List<DiscountDetail>()
            { 
                new DiscountDetail
                {
                ProductId = 3,
                DiscountId = 1,
                DiscountedProductID = 3,
                DiscountType = new DiscountType
                {
                    Type = "Percentage",
                    Id = 2
                },
                Discount =new Discount
                {
                    Id=1,
                    DiscountCode="BOGO"
                },
                DiscountValue = 100,
                QuantityThreshold = 1,
                IsUnLimited = true,
                IsActive = true

            } };
        }
        public static List<CheckoutResponse> GetCheckoutResponse()
        {
            return new List<CheckoutResponse>()
            {
                 new CheckoutResponse()
                {
                ProductId = 3,
                ProductCode = "CF1",
                ProductName = "Coffee",
                Price = 11.23,
                Quantity = 2
                }
            };
        }
    }
}
