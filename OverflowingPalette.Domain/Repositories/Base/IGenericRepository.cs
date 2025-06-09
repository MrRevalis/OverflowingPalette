using OverflowingPalette.Domain.Models.Base;

namespace OverflowingPalette.Domain.Repositories.Base
{
    public interface IGenericRepository<T>
            where T : class, IBaseEntity
    {
        Task AddAsync(T entity);
        Task DeleteAsync(T entity);
        Task UpdateAsync(T entity, T updatedEntity);
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<bool> DeleteByIdAsync(int id);
        IQueryable<T> Get();
    }
}