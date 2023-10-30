using ShoppingApp.Data.Models;

namespace ShoppingApp.Data.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<List<AppUserProductItem>> GetAllUserProducts(string userId);
        Task<T> GetByIdAsync(int id);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task Delete(int id);
    }
}