﻿using LocalFarm.Application.Repositories;
using LocalFarm.Persistence.Context;

namespace LocalFarm.Persistence.Repositories
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly DataContext _context;

        public UnitOfWork(DataContext context)
        {
            _context = context;
        }
        public Task Save(CancellationToken cancellationToken)
        {
            return _context.SaveChangesAsync(cancellationToken);
        }
    }
}
