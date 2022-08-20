using BinhDinhFood.Models;
using BinhDinhFoodWeb.Intefaces;
using Microsoft.AspNetCore.Mvc;

namespace BinhDinhFoodWeb.Controllers
{
    public class ProductGridViewController : Controller
    {
        private readonly IProductRepository _repo;
        public ProductGridViewController(IProductRepository repo)
        {
            _repo = repo;
        }
        public async Task<IActionResult> Index()
        {
            var objProductList = await _repo.GetProducts();
            return View(objProductList);
        }
    }
}
