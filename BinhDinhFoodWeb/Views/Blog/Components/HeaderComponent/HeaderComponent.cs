using Microsoft.AspNetCore.Mvc;

namespace BinhDinhFood.Views.Blog.Components.HeaderComponent;

public class HeaderComponent : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync()
    {
        return View();
    }
}
