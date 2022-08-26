using BinhDinhFood.Models;
using BinhDinhFoodWeb.Intefaces;
using BinhDinhFoodWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace BinhDinhFoodWeb.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _repoProduct;
        private readonly ICategoryRepository _repoCategory;
        public ProductController(IProductRepository repoProduct, ICategoryRepository repoCategory)
        {
            _repoProduct = repoProduct;
            _repoCategory = repoCategory;  
        }
        public async Task<IActionResult> Index()
        {
            var objProductList = await _repoProduct.GetAllProductsAsync();
            var objCategory = await _repoCategory.Get();
            ViewData["ListCategory"] = objCategory;
            return View(objProductList);
        }
        // Product Details page
        public async Task<IActionResult> ProductDetail(int id)
        {
            var obj = await _repoProduct.GetProductByIdAsync(id);
            return View(obj);
        }
        // Write review for PD ???
        public async Task<IActionResult> LeaveReview(int id)
        {
            var obj = await _repoProduct.GetProductByIdAsync(id);
            return View(obj);
        }
        [HttpPost]
        public async Task<IActionResult> LeaveReview(IFormCollection form, int id)
        {

            return RedirectToAction("Confirm");
        }

        // Confirm feature
        public IActionResult Confirm()
        {
            return View();
        }
        // Search feature
        public async Task<IActionResult> SearchByFilter(string name, int? categoryId)
        {
            List<Product> obj;
            if (string.IsNullOrEmpty(name))
            {
                
                obj = await _repoProduct.GetAllProductsAsync();
                obj.Where(x => x.CategoryId == categoryId);
            }
            else
            {
                obj = await _repoProduct.SearchByFilter(name);
            }
            var objCategory = await _repoCategory.Get();
            ViewData["ListCategory"] = objCategory;

            return View(obj);
        }
    }
}
