using LocalFarm.Domain.Common;

namespace LocalFarm.Application.Repositories
{
    public interface IProductRepository :IBaseRepository<Product>
    {
        Task<IList<Product>> GetAllProducts(CancellationToken cancellationToken);
        Task<Product> GetProductById(int id, CancellationToken cancellationToken);
    }
}
