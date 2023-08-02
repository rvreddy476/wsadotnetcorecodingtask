namespace LocalFarm.Application.UnitTests.Features
{
    [TestFixture]
    public class CheckoutHandlerTests
    {
        private readonly Mock<IDiscountRepository> _mockDiscountRepository;
        private readonly Mock<IProductRepository> _mockProductRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly CheckoutHandler _setUp;
        public CheckoutHandlerTests()
        {
            _mockDiscountRepository = new Mock<IDiscountRepository>();
            _mockMapper = new Mock<IMapper>();
            _mockProductRepository = new Mock<IProductRepository>();
            _setUp = new CheckoutHandler(_mockDiscountRepository.Object,_mockProductRepository.Object,_mockMapper.Object);
        }
        [Test]
        public async Task Test_Handle_With_BOGO_Discount()
        {
            //Arrange
            var discount = 11.23;
            var cartProducts = TestData.GetCartProducts();
            var discountDetail = TestData.GetAllDiscountDetails();
            var listCheckoutResponse = TestData.GetCheckoutResponse();
            _mockMapper.
                Setup(x => x.Map<List<CheckoutResponse>>(cartProducts))
                .Returns(listCheckoutResponse);
            _mockDiscountRepository.Setup(x => x.GetAllDiscountDetails(It.IsAny<CancellationToken>()))
                .ReturnsAsync(discountDetail);

            //Act
            var response =await _setUp.Handle(new CheckoutRequest(cartProducts),new CancellationToken());

            //Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(discount, response[0].Discount);

        }
    }
}
