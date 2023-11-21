using Domain.Entities;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class ProviderRepository : IProviderRepository
    {
        private RepositoryDbContext _dbContext;
        public ProviderRepository(RepositoryDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<IEnumerable<Provider>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return Task.Run(() => _dbContext.Providers.AsEnumerable());
        }


        public Task<Provider> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return Task.Run(() => _dbContext.Providers.FirstOrDefault(p => p.Id == id));
        }

        public void Insert(Provider t)
        {
            _dbContext.Providers.Add(t);
        }

        public void Remove(Provider t)
        {
            _dbContext.Providers.Remove(t);
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return Task.Run(() => _dbContext.SaveChanges());
        }
    }
}
