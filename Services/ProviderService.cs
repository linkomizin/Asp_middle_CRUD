using Contarcts;
using Domain.Repositories;
using Services.Abstractions;
using Mapster;

namespace Services;

public class ProviderService : IProviderServices
{
    private IRepositoryManager _repositoryManager;
    public ProviderService(IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
    }
    public async Task<IEnumerable<ProviderDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var providers = await _repositoryManager.ProviderRepository.GetAllAsync(cancellationToken);
        if (providers is null)
        {
            // edit this to custom Exception!!
            throw new Exception();
        }

        var providersDto = providers.Adapt<IEnumerable<ProviderDto>>();
        return providersDto;
    }

    public async Task<ProviderDto> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<ProviderDto> CreateAsync(ProviderForCreationDto providerForCreationDto, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateAsync(int id, ProviderDto providerDto, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}