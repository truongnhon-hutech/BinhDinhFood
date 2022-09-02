using BinhDinhFood.Models;
using BinhDinhFoodWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BinhDinhFoodWeb.Views.Cart.Components.OderDetail
{
    public class OrderDetailComponent : ViewComponent
    {
        public IViewComponentResult Invoke(IEnumerable<OrderDetail> obj)
        {
            return View(obj);
        }
    }
}
