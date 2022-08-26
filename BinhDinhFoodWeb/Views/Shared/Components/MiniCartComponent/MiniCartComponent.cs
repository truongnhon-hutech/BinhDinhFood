using BinhDinhFoodWeb.Intefaces;
using BinhDinhFoodWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Drawing.Printing;

namespace BinhDinhFoodWeb.Views.Cart.Components.MiniCartComponent
{
    public class MiniCartComponent:ViewComponent
    {
        private readonly ICartRepository _cartRepo;
        public MiniCartComponent(ICartRepository cartRepo)
        {
            _cartRepo = cartRepo;
        }
        public double TotalMoney()
        {
            double totalMoney = 0;
            List<Item> listCart = _cartRepo.Get(HttpContext.Session);
            if (listCart != null)
            {
                totalMoney = listCart.Sum(x => x.Quantity * x.Product.ProductPrice);
            }
            return totalMoney;
        }
        public IViewComponentResult Invoke()
        {
            var cart = _cartRepo.Get(HttpContext.Session);
            ViewData["TotalMoney"] = TotalMoney();
            ViewData["Count"] = cart.Count();
            return View(cart);
        }
    }
}
