using BinhDinhFood.Models;
using BinhDinhFoodWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BinhDinhFoodWeb.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        //BinhDinhFoodDbContext _db = new BinhDinhFoodDbContext(options);
        private readonly BinhDinhFoodDbContext _db;
        public HomeController(BinhDinhFoodDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Product> objProductList = _db.Products.Take(8);
            //var objProductList = _db.Products.ToList();
            return View(objProductList);
        }
        // Seperate later
        public IActionResult AcListNewPd()
        {
            IEnumerable<Product> objProductList = _db.Products.Take(8);
            return PartialView(objProductList);
        }
        public IActionResult AcListBestSellPd()
        {
            IEnumerable<Product> objProductList = _db.Products;
            return PartialView(objProductList);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}