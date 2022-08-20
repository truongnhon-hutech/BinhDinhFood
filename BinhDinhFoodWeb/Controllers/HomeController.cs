using BinhDinhFood.Models;
using BinhDinhFoodWeb.Intefaces;
using BinhDinhFoodWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Globalization;

namespace BinhDinhFoodWeb.Controllers
{
    public class HomeController : Controller
    {
        CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");
        private readonly IProductRepository _repo;
        public HomeController(IProductRepository repo)
        {
            _repo = repo;
        }
        public IActionResult Index()
        {
            var objProductList = _repo.GetProducts();

            // search data for banner
            var tmp1 = _repo.GetProductById(6);
            ViewData["objBannerName1"] = tmp1.ProductName;
            ViewData["objBannerImage1"] = tmp1.ProductImage;
            ViewData["objBannerPrice1"] = tmp1.ProductPrice.ToString("#,###", cul.NumberFormat);
            var tmp2 = _repo.GetProductById(7);

            ViewData["objBannerName2"] = tmp2.ProductName;
            ViewData["objBannerImage2"] = tmp2.ProductImage;
            ViewData["objBannerPrice2"] = tmp2.ProductPrice.ToString("#,###", cul.NumberFormat);
            var tmp3 = _repo.GetProductById(16);

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