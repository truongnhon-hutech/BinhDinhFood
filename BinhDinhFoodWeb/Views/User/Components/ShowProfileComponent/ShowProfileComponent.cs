using Microsoft.AspNetCore.Mvc;

namespace BinhDinhFoodWeb.Views.User.Components.ShowProfileComponent
{
    public class ShowProfileComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
