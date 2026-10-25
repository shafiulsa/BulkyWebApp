using BulkyBook.Models;
using BulkyBook.DataAccess.Data;
using Microsoft.AspNetCore.Mvc;
using BulkyBook.Business.Services.IServices;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace bulkyWebApp.Controllers;

[Area("Customer")]
public class ProductController : Controller
{
    private readonly IProductService _productService;
    private readonly ICategoryService _categoryService;
    public ProductController(IProductService productService, ICategoryService categoryService)
    {
        _productService = productService;
        _categoryService = categoryService;
    }
    public async Task<IActionResult> Index()
    {
        var products = await _productService.GetAllProductsAsync();
        return View();
    }

    public async Task<IActionResult> Upsert()
    {
        IEnumerable<SelectListItem> categoryList = (await _categoryService.GetAllCategoriesAsync())
            .Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.CategoryId.ToString()
            });
        ViewBag.CategoryList = categoryList;

        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [ActionName("Upsert")]
    public async Task<IActionResult> UpsertPOST(Product product)
    {

        if (ModelState.IsValid)
        {
            await _productService.CreateProductAsync(product);
            TempData["success"] = "Product created successfully";
            return RedirectToAction("Index");
        }
        return View();
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }

        var product = await _productService.GetProductByIdAsync(id.Value);
        if (product == null)
        {
            return NotFound();
        }

        return View(product);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    [ActionName("Delete")]
    public async Task<IActionResult> DeletePOST(int id)
    {
        await _productService.DeleteProductAsync(id);
        TempData["success"] = "Product deleted successfully";
        return RedirectToAction("Index");

    }

    #region API CALLS 
    public async Task<IActionResult> GetAll()
    {
        var products = await _productService.GetAllProductsAsync(true);
        return Json(new { data = products });
    }
    #endregion
}