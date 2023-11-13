using Contarcts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstractions
{
    public interface IOrderServices
    {
        Task<IEnumerable<OrderDto>> GetAllAsync(CancellationToken cancellationToken = default);

        Task<OrderDto> GetByIdAsync(int id, CancellationToken cancellationToken = default);

        Task<OrderDto> CreateAsync(OrderForCreationDto orderForCreationDto, CancellationToken cancellationToken = default);

        Task UpdateAsync(int id, OrderDto orderDto, CancellationToken cancellationToken = default);

        Task DeleteAsync(int id, CancellationToken cancellationToken = default);
    }
}
