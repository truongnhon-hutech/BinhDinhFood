using BinhDinhFood.Models;
using BinhDinhFoodWeb.Intefaces;
using BinhDinhFoodWeb.Models;
using BinhDinhFoodWeb.Repositories;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Globalization;
using System.Net.NetworkInformation;
using System.Security.Claims;

namespace BinhDinhFoodWeb.Controllers
{
    public class CartController : Controller
    {
        CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");
        
        private readonly ICartRepository _cartRepo;
        private readonly IProductRepository _productRepo;
        public CartController(ICartRepository cartRepo, IProductRepository productRepo)
        {
            _cartRepo = cartRepo;
            _productRepo = productRepo;
        }
        public IActionResult Index()
        {
            var shippingCost = 3000;
            List<Item> listCart = _cartRepo.Get(HttpContext.Session);
            ViewData["TotalSubMoney"] = TotalMoney();
            ViewData["ShippingCost"] = shippingCost;
            ViewData["TotalMoney"] = shippingCost + TotalMoney();

            return View(listCart);
        }
        public IActionResult UpdateCart()
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Login", "User");
            List<Item> cart = _cartRepo.Get(HttpContext.Session);
            var shippingCost = 300000;
            ViewData["TotalSubMoney"] = TotalMoney().ToString("#,###", cul.NumberFormat); ;
            ViewData["ShippingCost"] = shippingCost.ToString("#,###", cul.NumberFormat); ;
            ViewData["TotalMoney"] = (shippingCost + TotalMoney()).ToString("#,###", cul.NumberFormat); ;
            return ViewComponent("CartComponent", cart);
        }
        // sum all money 
        public IActionResult UpdateItem(int id, int value)
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Login", "User");
            List<Item> listCart = _cartRepo.Get(HttpContext.Session);
            Item cart = listCart.FirstOrDefault(x => x.Product.ProductId == id);
            if (cart != null)
            {
                var quantity = cart.Quantity + value;
                if (quantity >= 0)
                    cart.Quantity = quantity;
                    _cartRepo.Set(HttpContext.Session, listCart);
            }
            return ViewComponent("ItemComponent", cart);
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
        // Add product to cart
        public async Task<IActionResult> AddInCart(int id)
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Login", "User");
            List<Item> listCart = _cartRepo.Get(HttpContext.Session);
            bool isInCart = listCart.Any(x => x.Product.ProductId == id);
            if (!isInCart)
            {
                Item newItem = new Item { Product = await _productRepo.GetByIdAsync(id), Quantity = 1 };
                listCart.Add(newItem);
            }
            else
            {
                Item? item = listCart.FirstOrDefault(x => x.Product.ProductId == id);
                item.Quantity++;
            }
            _cartRepo.Set(HttpContext.Session, listCart);
            return ViewComponent("MiniCartComponent");
        }
        // remove product in cart
        public IActionResult RemoveInCart(int id)
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Login", "User");
            List<Item> listCart = _cartRepo.Get(HttpContext.Session);
            bool cart = listCart.Any(x => x.Product.ProductId == id);
            if (cart)
            {
                listCart.RemoveAll(x => x.Product.ProductId == id);
                _cartRepo.Set(HttpContext.Session, listCart);
            }

            return ViewComponent("CartComponent", listCart);
        }
        public IActionResult RemoveInMiniCart(int id)
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Login", "User");
            List<Item> listCart = _cartRepo.Get(HttpContext.Session);
            bool cart = listCart.Any(x => x.Product.ProductId == id);
            if (cart)
            {
                listCart.RemoveAll(x => x.Product.ProductId == id);
                _cartRepo.Set(HttpContext.Session, listCart);
            }

            return ViewComponent("MiniCartComponent");
        }

        // remove all product in cart
        public IActionResult RemoveAll()
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Login", "User");
            _cartRepo.Set(HttpContext.Session, new List<Item>());
            return ViewComponent("CartComponent", new List<Item>());
        }
        // Order - checkout
        public IActionResult Order()
        {
            if(!User.Identity.IsAuthenticated)
                return RedirectToAction("Login", "User");
            
            List<Item> listCart = _cartRepo.Get(HttpContext.Session);
            
            int id = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            //Customer customer =
            if (listCart == null)
                return RedirectToAction("Order", "Cart");
            
            var shippingCost = 300000;
            ViewData["TotalSubMoney"] = TotalMoney().ToString("#,###", cul.NumberFormat);
            ViewData["ShippingCost"] = shippingCost.ToString("#,###", cul.NumberFormat);
            ViewData["TotalMoney"] = (shippingCost + TotalMoney()).ToString("#,###", cul.NumberFormat);

            return View(listCart);
        }
        [HttpPost]
        public IActionResult Order(IFormCollection form)
        {
            int id = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));

            return View();
        }
        public IActionResult Checkout()
        {

            return View();
        }
        // Comfirm order
        public IActionResult Comfirm()
        {
            return View();
        }
        // Track your order
        public IActionResult TrackOder()
        {
            return View();
        }
    }
}
