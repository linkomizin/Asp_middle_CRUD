using Contarcts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstractions
{
    public interface IOrderItemServices
    {
        Task<IEnumerable<OrderItemDto>> GetAllAsync(CancellationToken cancellationToken = default);

        Task<OrderItemDto> GetByIdAsync(int id, CancellationToken cancellationToken = default);

        Task<OrderItemDto> CreateAsync(OrderItemForCreationDto orderItemForCreationDto, CancellationToken cancellationToken = default);

        Task UpdateAsync(int id, OrderItemDto orderDto, CancellationToken cancellationToken = default);

        Task DeleteAsync(int id, CancellationToken cancellationToken = default);
    }
}
