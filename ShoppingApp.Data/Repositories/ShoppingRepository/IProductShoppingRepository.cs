using ShoppingApp.Data.DTOs;
using ShoppingApp.Data.Models;

namespace ShoppingApp.Data.Repositories.ShoppingRepository
{
    public interface IProductShoppingRepository
    {
        Task AddUserProductAsync(ProductItemDto product, string userId);

        Task<AppUserProductItem> GetUserProductAsync(int productId, string userId);

        Task UpdateUserProductAsync(ProductItemDto product, string userId);

        Task DeleteUserProduct(int productId, string userId);

        Task<List<AppUserProductItem>> GetUserProductsAsync(string userId);
    }
}