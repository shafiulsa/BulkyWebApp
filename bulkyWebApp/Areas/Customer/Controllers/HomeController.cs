using System.Diagnostics;
using System.Security.Claims;
using BulkyBook.Business;
using BulkyBook.Business.Services.IServices;
using BulkyBook.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace bulkyWebApp.Controllers;

[Area("Customer")]

public class HomeController : Controller
{
    private readonly IProductService _productService;
    private readonly IShoppingCartService _shoppingCartService;
    public HomeController(IProductService productService, IShoppingCartService shoppingCartService)
    {
        _productService = productService;
        _shoppingCartService = shoppingCartService;
    }
    public async Task<IActionResult> Index()
    {
        var products=await _productService.GetAllProductsAsync(includeCategories:true);
        return View(products);
    }

    [HttpGet]
    public async Task<IActionResult> Details(int productId)
    {
        var product = await _productService.GetProductByIdAsync(productId, includeCategory: true);
        if (product == null)
        {
            return NotFound();
        }

        var cart = new ShoppingCart
        {
            Product = product,
            ProductId = productId,
            Count = 1
        };

        return View(cart);
    }

  [HttpPost]
        [Authorize]
        public async Task<IActionResult> Details(ShoppingCart shoppingCart)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized();
            }

            shoppingCart.ApplicationUserId = userId;
            await _shoppingCartService.AddToCartAsync(shoppingCart);
            
            return RedirectToAction("Details",new { productId = shoppingCart.ProductId });
        }

}
