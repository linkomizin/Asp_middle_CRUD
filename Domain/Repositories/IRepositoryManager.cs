
namespace Domain.Repositories
{
    public interface IRepositoryManager
    {
        IOrderRepository OrderRepository { get; }
        IOrderItemRepository OrderItemRepository { get; }
        IProviderRepository ProviderRepositorey { get; }
    }
}
