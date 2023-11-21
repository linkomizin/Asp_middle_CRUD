using Contarcts;
using Domain.Repositories;
using Services.Abstractions;
using Mapster;
using Domain.Entities;

namespace Services
{
    public class OrderService : IOrderServices
    {
        private IRepositoryManager _repositoryManager;
        public OrderService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }
        public async Task<OrderDto> CreateAsync(OrderForCreationDto orderForCreationDto, CancellationToken cancellationToken = default)
        {
            var order = orderForCreationDto.Adapt<Order>();
            _repositoryManager.OrderRepository.Insert(order);
            await _repositoryManager.OrderRepository.SaveChangesAsync(cancellationToken);
            return order.Adapt<OrderDto>();
        }

        public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
             var order = await _repositoryManager.OrderRepository.GetByIdAsync(id, cancellationToken);
            if(order is null)
            {
                // edit this to custom Exception!!
                throw new Exception();
            }

            _repositoryManager.OrderRepository.Remove(order);
            await _repositoryManager.OrderRepository.SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<OrderDto>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var orders = await _repositoryManager.OrderRepository.GetAllAsync(cancellationToken);
            var orderDto = orders.Adapt<IEnumerable<OrderDto>>();
            return orderDto;
        }

        public async Task<OrderDto> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var order = await _repositoryManager.OrderRepository.GetByIdAsync(id, cancellationToken);
            if (order is null)
            {
                // edit this to custom Exception!!
                throw new Exception();
            }

            var orderDto = order.Adapt<OrderDto>(); 
            return orderDto;
        }

        public async Task UpdateAsync(int id, OrderDto orderDto, CancellationToken cancellationToken = default)
        {
            var order = await _repositoryManager.OrderRepository.GetByIdAsync(id, cancellationToken);
            if(order is null)
            {
                // edit this to custom Exception!!
                throw new Exception();
            }

            order.Number = orderDto.Number;
            order.Date = orderDto.Date;
            order.ProviderId = orderDto.ProviderId;

            await _repositoryManager.OrderRepository.SaveChangesAsync(cancellationToken);

        }
    }
}
