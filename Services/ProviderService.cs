using Contarcts;
using Domain.Repositories;
using Services.Abstractions;
using Mapster;
using Domain.Entities;

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
        var finded = await _repositoryManager.ProviderRepository.GetByIdAsync(id, cancellationToken);
        if (finded is null)
        {
            // edit this to custom Exception!!
            throw new Exception();
        }
        var providerDto = finded.Adapt<ProviderDto>();
        return providerDto;
    }

    public async Task<ProviderDto> CreateAsync(ProviderForCreationDto providerForCreationDto, CancellationToken cancellationToken = default)
    {
        var provider = providerForCreationDto.Adapt<Provider>();
        _repositoryManager.ProviderRepository.Insert(provider);
        await _repositoryManager.ProviderRepository.SaveChangesAsync(cancellationToken);
        return provider.Adapt<ProviderDto>();
    }

    public async Task UpdateAsync(int id, ProviderDto providerDto, CancellationToken cancellationToken = default)
    {
        var provider = await _repositoryManager.ProviderRepository.GetByIdAsync(id, cancellationToken);
        if (provider is null)
        {
            // edit this to custom Exception!!
            throw new Exception();
        }
        provider.Name = providerDto.Name;
        await _repositoryManager.ProviderRepository.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        var provider = await _repositoryManager.ProviderRepository.GetByIdAsync(id, cancellationToken);
        if(provider is null)
        {
            // edit this to custom Exception!!
            throw new Exception();
        }
        _repositoryManager.ProviderRepository.Remove(provider);
        await _repositoryManager.ProviderRepository.SaveChangesAsync();
    }
}