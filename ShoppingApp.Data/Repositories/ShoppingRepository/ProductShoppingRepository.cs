using ShoppingApp.Data.DTOs;
using ShoppingApp.Data.Models;

namespace ShoppingApp.Data.Repositories.ShoppingRepository
{
    public class ProductShoppingRepository : IProductShoppingRepository
    {
        private readonly IRepository<AppUserProductItem> _userProductRepository;
        private readonly IRepository<ProductItem> _productRepository;

        public ProductShoppingRepository(IRepository<AppUserProductItem> userProductRepository, IRepository<ProductItem> productRepository)
        {
            _userProductRepository = userProductRepository;
            _productRepository = productRepository;
        }

        public async Task AddUserProductAsync(ProductItemDto product, string userId)
        {
           await _userProductRepository.AddAsync(new AppUserProductItem { ProductItem = new ProductItem { }, UserId = userId });
        }

        public async Task<AppUserProductItem> GetUserProductAsync(int productId, string userId)
        {
            var product = await _userProductRepository.GetByIdAsync(productId);
            if (product.UserId != userId) { return null ; } 
            return product;
        }

        public async Task UpdateUserProductAsync(ProductItemDto product, string userId)
        {
            if (!product.ProductId.HasValue)
            {
                throw new NullReferenceException("product does not exsist.");
            }

            var returnedProduct = await _userProductRepository.GetByIdAsync(product.ProductId.Value);

            if (returnedProduct.UserId != userId) { throw new NullReferenceException("invalid user."); }

            returnedProduct.ProductItem = new ProductItem
            {
                ProductName = product.ProductName,
                Image = product.Image,
            };

            await _userProductRepository.UpdateAsync(returnedProduct);
        }

        public async Task DeleteUserProduct(int productId, string userId)
        {
            var returnedProduct = await _userProductRepository.GetByIdAsync(productId);

            if (returnedProduct.UserId != userId) { throw new NullReferenceException("invalid user."); }

            await _userProductRepository.Delete(productId);
        }

        public async Task<List<AppUserProductItem>> GetUserProductsAsync(string userId)
        {
            List<AppUserProductItem> products = await _productRepository.GetAllUserProducts(userId);

            return products;
        }
    }
}
