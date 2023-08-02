using LocalFarm.Application.Repositories;
using LocalFarm.Domain.Common;
using LocalFarm.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalFarm.Persistence.Repositories
{
    public class DiscountRepository : BaseRepository<Discount>, IDiscountRepository
    {
        public DiscountRepository(DataContext context) : base(context) { }

        public async Task<IList<Discount>> GetAllDiscount(CancellationToken cancellationToken)
        {
            return await Context.Discounts.ToListAsync(cancellationToken);
        }

        public async Task<IList<DiscountDetail>> GetAllDiscountDetails(CancellationToken cancellationToken)
        {
            return await Context.DiscountDetails.Where(x=>x.IsActive==true).Include(x=>x.Discount)
                                                .Include(x => x.DiscountType)
                                                .ToListAsync(cancellationToken);            
        }
    }
}
