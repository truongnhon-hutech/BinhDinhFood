using Microsoft.AspNetCore.Mvc;

namespace BinhDinhFoodWeb.Areas.Admin.Views.AdmStatistics.Components.StaticProductComponent
{
    public class StaticProductComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
