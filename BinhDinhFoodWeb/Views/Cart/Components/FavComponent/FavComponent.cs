using BinhDinhFoodWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BinhDinhFoodWeb.Views.Cart.Components.FavComponent
{
    public class FavComponent : ViewComponent
    {
        public IViewComponentResult Invoke(IEnumerable<Favorite> fav)
        {
            return View(fav);
        }
    }
}
