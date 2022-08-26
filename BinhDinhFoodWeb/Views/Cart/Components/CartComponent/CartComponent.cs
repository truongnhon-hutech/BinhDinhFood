using BinhDinhFoodWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BinhDinhFoodWeb.Views.Cart.Components.CartComponent
{
	public class CartComponent : ViewComponent
	{
        public IViewComponentResult Invoke(IEnumerable<Item> list)
        {
            return View(list);
        }
    }
}
