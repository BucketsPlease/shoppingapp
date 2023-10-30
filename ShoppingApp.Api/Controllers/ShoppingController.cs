using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ShoppingApp.Data.DTOs;
using ShoppingApp.Data.Models;
using ShoppingApp.Data.Repositories.ShoppingRepository;
using System.Security.Claims;

namespace ShoppingApp.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ShoppingController : Controller
    {
        private readonly IProductShoppingRepository _productShoppingRepository;
        private readonly UserManager<AppUser> _userManager;
        public ShoppingController(IProductShoppingRepository productShoppingRepository, UserManager<AppUser> userManager)
        {
            _productShoppingRepository = productShoppingRepository;
            _userManager = userManager;
        }

        [HttpPost("AddProduct")]
        [Authorize]
        public async Task<IActionResult> AddProduct(ProductItemDto product)
        {
            try
            {
                var user = await GetCurrentLoggedInUser();
                await _productShoppingRepository.AddUserProductAsync(product, user.Id);
                return Json("Product Added");
            }
            catch (Exception ex)
            {
                return Json($"error occured {ex.Message}");
            }
        }

        [HttpGet("GetUserProduct")]
        [Authorize]
        public async Task<IActionResult> GetUserProduct(int productId)
        {
            try
            {
                var user = await GetCurrentLoggedInUser();
                await _productShoppingRepository.GetUserProductAsync(productId, user.Id);
                return Json("Product Added");
            }
            catch (Exception ex)
            {
                return Json($"error occured {ex.Message}");
            }
        }

        [HttpGet("GetUserProducts")]
        [Authorize]
        public async Task<IActionResult> GetUserProducts(ProductItemDto product)
        {
            try
            {
                var user = await GetCurrentLoggedInUser();
                await _productShoppingRepository.GetUserProductsAsync(user.Id);
                return Json("Product Added");
            }
            catch (Exception ex)
            {
                return Json($"error occured {ex.Message}");
            }
        }

        [HttpPost("DeleteProduct")]
        [Authorize]
        public async Task<IActionResult> DeleteProduct(int productId)
        {
            try
            {
                var user = await GetCurrentLoggedInUser();
                await _productShoppingRepository.DeleteUserProduct(productId, user.Id);
                return Json("Product Added");
            }
            catch (Exception ex)
            {
                return Json($"error occured {ex.Message}");
            }
        }

        [NonAction]
        public async Task<AppUser> GetCurrentLoggedInUser()
        {
            var claimsIdentity = this.User.Identity as ClaimsIdentity;

            string userId = claimsIdentity?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (userId == null)
            {
                return null;
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return null;
            }

            return user;
        }
    }
}