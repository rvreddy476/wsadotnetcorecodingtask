using LocalFarm.Domain.Common;

namespace LocalFarm.Application.Repositories
{
    public interface IProductRepository :IBaseRepository<Product>
    {
        Task<IList<Product>> GetAllProducts(CancellationToken cancellationToken);
        Task<IList<DiscountDetail>> GetAllProductDiscounts(CancellationToken cancellationToken);
    }
}
