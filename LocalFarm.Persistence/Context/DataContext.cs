using LocalFarm.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace LocalFarm.Persistence.Context
{
    public class DataContext:DbContext
    {      
    
        public DbSet<Product> Products { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<DiscountType> DiscountsTypes { get; set; }
        public DbSet<DiscountDetail> DiscountDetails { get; set; }
        
    }
}
