using Contarcts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstractions
{
    public interface IProviderServices
    {
        Task<IEnumerable<ProviderDto>> GetAllAsync(CancellationToken cancellationToken = default);

        Task<ProviderDto> GetByIdAsync(int id, CancellationToken cancellationToken = default);

        Task<ProviderDto> CreateAsync(ProviderForCreationDto providerForCreationDto, CancellationToken cancellationToken = default);

        Task UpdateAsync(int id, ProviderDto providerDto, CancellationToken cancellationToken = default);

        Task DeleteAsync(int id, CancellationToken cancellationToken = default);
    }
}
