using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public sealed class RepositoryManager : IRepositoryManager
    {
        private readonly Lazy<IProviderRepository> _lazyProviderRepository;
        private readonly Lazy<IOrderItemRepository> _lazyItemRepository;
        private readonly Lazy<IOrderRepository> _lazyOrderRepository;


        public RepositoryManager(RepositoryDbContext dbContext)
        {
            _lazyProviderRepository = new Lazy<IProviderRepository>(() => new ProviderRepository(dbContext));
            _lazyItemRepository = new Lazy<IOrderItemRepository>(() => new ItemRepository(dbContext));
            _lazyOrderRepository = new Lazy<IOrderRepository>(() => new OrderRepository(dbContext));
        }
        public IOrderRepository OrderRepository => _lazyOrderRepository.Value;

        public IOrderItemRepository OrderItemRepository => _lazyItemRepository.Value;

        public IProviderRepository ProviderRepository => _lazyProviderRepository.Value;
    }
}
