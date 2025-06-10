using Microsoft.EntityFrameworkCore;
using ProductService.ApplicationCore.Repositories;
using ProductService.Infrastructure.Data;

namespace ProductService.Infrastructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly ProductDbContext _DbContext;
        public BaseRepository(ProductDbContext movieShopDbContext)
        {
            _DbContext = movieShopDbContext;
        }

        public async Task<T> Insert(T entity)
        {
            _DbContext.Set<T>().Add(entity);
            await _DbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<T> DeleteById(int id)
        {
            var entity = _DbContext.Set<T>().Find(id);
            if (entity != null)
            {
                _DbContext.Set<T>().Remove(entity);
                await _DbContext.SaveChangesAsync();
                return entity;
            }

            return null;
        }

        public async Task<T> Update(T entity)
        {
            _DbContext.Entry(entity).State = EntityState.Modified;
            await _DbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _DbContext.Set<T>().ToListAsync();
        }

        public virtual async Task<T> GetById(int id)
        {
            return await _DbContext.Set<T>().FindAsync(id);
        }
    }
}
