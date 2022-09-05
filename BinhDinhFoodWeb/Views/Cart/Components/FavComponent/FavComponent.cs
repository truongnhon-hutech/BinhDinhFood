using BinhDinhFoodWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BinhDinhFoodWeb.Views.Cart.Components.FavComponent
{
    public class FavComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(IEnumerable<Favorite> fav)
        {
            return View("FavComponent", fav);
        }
    }
}
