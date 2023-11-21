using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contarcts;
using Domain.Repositories;
using Services.Abstractions;

namespace Services
{
    public class OrderItemService : IOrderItemServices
    {

        private IRepositoryManager _repositoryManager;
        public OrderItemService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }
        public async Task<IEnumerable<OrderItemDto>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<OrderItemDto> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<OrderItemDto> CreateAsync(OrderItemForCreationDto orderItemForCreationDto, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(int id, OrderItemDto orderDto, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
