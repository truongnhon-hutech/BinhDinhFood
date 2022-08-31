using Microsoft.AspNetCore.Mvc;

namespace BinhDinhFoodWeb.Views.Shared.Components.AccountComponent
{
    public class AccountComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
