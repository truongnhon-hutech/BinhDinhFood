using Microsoft.AspNetCore.Mvc;

namespace BinhDinhFoodWeb.Views.User.Components.AvatarComponent
{
    public class AvatarComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
