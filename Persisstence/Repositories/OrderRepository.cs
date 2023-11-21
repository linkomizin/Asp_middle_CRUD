using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Repositories;

namespace Persistence.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private RepositoryDbContext _dbContext;
        public OrderRepository(RepositoryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<IEnumerable<Order>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var collection = _dbContext.Orders.ToList();
            return Task.Run(() => collection.AsEnumerable());
        }

        public Task<Order> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var order = _dbContext.Orders.FirstOrDefault(o => o.Id == id);
            if (order != null)
            {
                var lst = _dbContext.OrderItems
                        .Where(el => el.OrderId == order.Id)
                        .ToList();
                order.OrderItems = lst;
            }
            return Task.Run(() => order);
        }

        public void Insert(Order t)
        {
            _dbContext.Orders.Add(t);
        }

        public void Remove(Order t)
        {
            _dbContext.Orders.Remove(t);
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return Task.Run(() => _dbContext.SaveChanges());
        }
    }
}
