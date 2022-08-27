using BinhDinhFood.Models;
using BinhDinhFoodWeb.Intefaces;
using BinhDinhFoodWeb.Models;
using BinhDinhFoodWeb.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace BinhDinhFoodWeb.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _repoProduct;
        private readonly ICategoryRepository _repoCategory;
        private readonly IProductRatingRepository _repoProductRating;

        public ProductController(IProductRepository repoProduct, ICategoryRepository repoCategory, IProductRatingRepository repoProductRating)
        {
            _repoProduct = repoProduct;
            _repoCategory = repoCategory;
            _repoProductRating = repoProductRating;
        }
        public async Task<IActionResult> Index()
        {
            var objProductList = await _repoProduct.GetListAsync();
            var objCategory = await _repoCategory.GetListAsync();
            ViewData["ListCategory"] = objCategory;
            return View(objProductList);
        }
        // Product Details page
        public async Task<IActionResult> ProductDetail(int id)
        {
            var obj = await _repoProduct.GetByIdAsync(id);
            return View(obj);
        }
        // Write review for PD 
        public async Task<IActionResult> LeaveReview(int id)
        {
            var obj = await _repoProduct.GetByIdAsync(id);
            return View(obj);
        }
        [HttpPost]
        public async Task<IActionResult> LeaveReview(IFormCollection form, int id)
        {
            ProductRating pd = new ProductRating();
            pd.CustomerId = 1;
            pd.ProductId = id;
            pd.Stars = Convert.ToInt32(form["rating-input"]);
            pd.RatingContent = form["RatingContent"];
            pd.PRDateCreated = DateTime.Now;
            await _repoProductRating.AddAsync(pd);
            await _repoProductRating.SaveAsync();
            
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
            IEnumerable<Product> obj;
            if (string.IsNullOrEmpty(name))
            {
                
                obj = await _repoProduct.GetListAsync();
                obj.Where(x => x.CategoryId == categoryId);
            }
            else
            {
                obj = await _repoProduct.GetListAsync(filter: x=>x.ProductName.Contains(name));
            }
            var objCategory = await _repoCategory.GetListAsync();
            ViewData["ListCategory"] = objCategory;
            return View(obj);
        }
    }
}
