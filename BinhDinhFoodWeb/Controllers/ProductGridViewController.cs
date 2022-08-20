using BinhDinhFood.Models;
using Microsoft.AspNetCore.Mvc;

namespace BinhDinhFoodWeb.Controllers
{
    public class ProductGridViewController : Controller
    {
        private readonly BinhDinhFoodDbContext _db;
        public ProductGridViewController(BinhDinhFoodDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Product> objProductList = _db.Products.Take(8);
            return View(objProductList);
        }
    }
}
