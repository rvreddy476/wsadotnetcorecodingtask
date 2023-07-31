using LocalFarm.Application.Repositories;
using LocalFarm.Domain.Common;
using LocalFarm.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace LocalFarm.Persistence.Repositories
{
    public class ProductRepository :BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(DataContext context) : base(context){ }

       public async Task<IList<Product>> GetAllProducts(CancellationToken cancellationToken)=>
            await Context.Products.ToListAsync(cancellationToken);
        public async Task<IList<DiscountDetail>> GetAllProductDiscounts(CancellationToken cancellationToken)=>
            await Context.DiscountDetails.Include(x=>x.DiscountType).ToListAsync(cancellationToken);
        

    }
}
