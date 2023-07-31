using LocalFarm.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace LocalFarm.Persistence.Context
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
    
        public DbSet<Product> Products { get; set; }
        public DbSet<DiscountTypeId> Discounts { get; set; }
        public DbSet<DiscountType> DiscountsTypes { get; set; }
        public DbSet<DiscountDetail> DiscountDetails { get; set; }
        
    }
}
