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
            return View();
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