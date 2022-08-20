using BinhDinhFood.Models;
using BinhDinhFoodWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Globalization;

namespace BinhDinhFoodWeb.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");
        private readonly BinhDinhFoodDbContext _db;
        public HomeController(BinhDinhFoodDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Product> objProductList = _db.Products.Take(8);
            //var objProductList = _db.Products.ToList();
            var tmp1 = _db.Products.Find(6);
            ViewData["objBannerName1"] = tmp1.ProductName;
            ViewData["objBannerImage1"] = tmp1.ProductImage;
            ViewData["objBannerPrice1"] = tmp1.ProductPrice.ToString("#,###", cul.NumberFormat);
            var tmp2 = _db.Products.Find(7);
            ViewData["objBannerName2"] = tmp2.ProductName;
            ViewData["objBannerImage2"] = tmp2.ProductImage;
            ViewData["objBannerPrice2"] = tmp2.ProductPrice.ToString("#,###", cul.NumberFormat);
            var tmp3 = _db.Products.Find(16);
            ViewData["objBannerName3"] = tmp3.ProductName;
            ViewData["objBannerImage3"] = tmp3.ProductImage;
            ViewData["objBannerPrice3"] = tmp3.ProductPrice.ToString("#,###", cul.NumberFormat);

            return View(objProductList);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}