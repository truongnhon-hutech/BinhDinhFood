using Microsoft.AspNetCore.Mvc;

namespace BinhDinhFoodWeb.Views.Blog.Components.HeaderComponent
{
    public class HeaderComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
