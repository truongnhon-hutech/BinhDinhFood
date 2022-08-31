using Microsoft.AspNetCore.Mvc;

namespace BinhDinhFoodWeb.Views.User.Components.PreLoadingComponent
{
    public class PreLoadingComponent :ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
