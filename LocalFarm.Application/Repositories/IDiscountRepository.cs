using LocalFarm.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalFarm.Application.Repositories
{
    public interface IDiscountRepository : IBaseRepository<Discount>
    {
        Task<IList<Discount>> GetAllDiscount(CancellationToken cancellationToken);
        Task<IList<DiscountDetail>> GetAllDiscountDetails(CancellationToken cancellationToken);
    }
}
