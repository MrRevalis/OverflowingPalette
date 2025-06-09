using Microsoft.EntityFrameworkCore;
using OverflowingPalette.Domain.Data;
using OverflowingPalette.Domain.Models.Base;
using System.Linq.Expressions;

namespace OverflowingPalette.Domain.Repositories.Base
{
    public class GenericRepository<T> : IGenericRepository<T>
        where T : class, IBaseEntity
    {
        private readonly OverflowingPaletteDbContext _dbContext;
        private DbSet<T> _dbSet;

        public GenericRepository(OverflowingPaletteDbContext dbContext)
        {
            this._dbContext = dbContext;
            this._dbSet = dbContext.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            await this._dbSet.AddAsync(entity);

            await this._dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            this._dbSet.Remove(entity);

            await this._dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity, T updatedEntity)
        {
            this._dbContext
                .Entry(entity)
                .CurrentValues
                .SetValues(updatedEntity);

            await this._dbContext.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await this._dbSet
                .ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await this._dbSet.FindAsync(id);
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            var result = await this._dbSet
                .Where(x => x.Id == id)
                .ExecuteDeleteAsync();

            return result > 0;
        }

        public async Task<T?> GetFirstOrDefaultAsync(Expression<Func<T, bool>>? filter = null, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _dbSet;

            foreach (var includeExpression in includes)
            {
                query = query.Include(includeExpression);
            }

            if (filter != null)
            {
                query = query.Where(filter);
            }

            return await query.FirstOrDefaultAsync();
        }

        public IQueryable<T> Get()
        {
            return _dbSet;
        }
    }
}
