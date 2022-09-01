using BinhDinhFood.Models;
using Microsoft.AspNetCore.Mvc;

namespace BinhDinhFoodWeb.Views.Cart.Components.Orders
{
    public class OrdersComponent : ViewComponent
    {
        public IViewComponentResult Invoke(IEnumerable<Order> obj) 
        { 
            return View(obj); 
        }
    }
}
