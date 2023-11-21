using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Repositories;

namespace Persistence.Repositories
{
    public class ItemRepository : IOrderItemRepository
    {
        private RepositoryDbContext _dbContext;
        public ItemRepository(RepositoryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<IEnumerable<OrderItem>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var collection = _dbContext.OrderItems.ToList();
            return Task.Run(() => collection.AsEnumerable());
        }

        public Task<OrderItem> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var orderItem = _dbContext.OrderItems.FirstOrDefault(o => o.Id == id);
            return Task.Run(() => orderItem);
        }

        public void Insert(OrderItem t)
        {
           _dbContext.OrderItems.Add(t);
        }

        public void Remove(OrderItem t)
        {
            _dbContext.OrderItems.Remove(t);
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return Task.Run(() => _dbContext.SaveChanges());
        }
    }
}
