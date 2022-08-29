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
        public async Task<IActionResult> Index()
        {
            // search data for banner
            var tmp1 = await _repo.GetByIdAsync(6);
            ViewData["objBannerImage1"] = tmp1.ProductImage;
            var tmp2 = await _repo.GetByIdAsync(7);

            ViewData["objBannerImage2"] = tmp2.ProductImage;
            var tmp3 = await _repo.GetByIdAsync(16);

            ViewData["objBannerImage3"] = tmp3.ProductImage;
            var objProductList = await _repo.GetListAsync();
            return View(objProductList);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]

        public IActionResult Error(int statuscode)
        {
            if (statuscode == 404)
                return View("NotFound");
            else
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult About()
        {
            return View();

        }
        public IActionResult Help()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
        
    }
}