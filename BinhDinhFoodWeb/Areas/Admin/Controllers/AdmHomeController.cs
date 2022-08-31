using Microsoft.AspNetCore.Mvc;

namespace BinhDinhFoodWeb.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class AdmHomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
