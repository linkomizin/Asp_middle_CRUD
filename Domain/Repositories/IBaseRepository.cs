﻿
namespace Domain.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<T> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        void Insert(T t);
        void Remove(T t);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
