using Microsoft.EntityFrameworkCore;
using ShoppingApp.Data.Context;
using ShoppingApp.Data.Models;

namespace ShoppingApp.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ShoppingAppContext _shoppingAppContext;
        public Repository(ShoppingAppContext shoppingAppContext)
        {
            _shoppingAppContext = shoppingAppContext;
        }

        public async Task<List<AppUserProductItem>> GetAllUserProducts(string userId)
        {
            return await _shoppingAppContext.Set<AppUserProductItem>().Where(up => up.UserId == userId).ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _shoppingAppContext.Set<T>().FindAsync(id);
        }

        public async Task AddAsync(T entity)
        {
            await _shoppingAppContext.Set<T>().AddAsync(entity);
            await _shoppingAppContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _shoppingAppContext.Set<T>().Update(entity);
            await _shoppingAppContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                _shoppingAppContext.Set<T>().Remove(entity);
                await _shoppingAppContext.SaveChangesAsync();
            }
        }
    }
}
