using BinhDinhFood.Models;
using BinhDinhFoodWeb.Intefaces;
using BinhDinhFoodWeb.Models;
using BinhDinhFoodWeb.Repositories;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BinhDinhFoodWeb.Controllers
{
    public class CartController : Controller
    {
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
            List<Item> cart = _cartRepo.Get(HttpContext.Session);
            var shippingCost = 300000;
            ViewData["TotalSubMoney"] = TotalMoney();
            ViewData["ShippingCost"] = shippingCost;
            ViewData["TotalMoney"] = shippingCost + TotalMoney();
            return ViewComponent("CartComponent", cart);
        }
        // sum all money 
        public IActionResult UpdateItem(int id, int value)
        {
            List<Item> listCart = _cartRepo.Get(HttpContext.Session);
            Item cart = listCart.FirstOrDefault(x => x.Product.ProductId == id);
            if (cart != null)
            {
                var quantity = cart.Quantity + value;
                if (quantity < 0)
                {
                }
                else
                {
                    cart.Quantity = quantity;
                    _cartRepo.Set(HttpContext.Session, listCart);
                }
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
            _cartRepo.Set(HttpContext.Session, new List<Item>());
            return ViewComponent("CartComponent", new List<Item>());
        }
        // Order - checkout
        [HttpGet]
        public IActionResult Order()
        {
            List<Item> listCart = _cartRepo.Get(HttpContext.Session);

            if (listCart != null)
                return RedirectToAction("Order", "Cart");
            var shippingCost = 300000;
            ViewData["TotalSubMoney"] = TotalMoney();
            ViewData["ShippingCost"] = shippingCost;
            ViewData["TotalMoney"] = shippingCost + TotalMoney();

            return View(listCart);
        }
        [HttpPost]
        public IActionResult Order(IFormCollection form)
        {
            // code the view for order fix other bugs to rebuild 
            // call form, declare object, save in database
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
        // Partial View
        // list product
        // total product or viewbag and transmissive to another controller
        public IActionResult ListProductPartial()
        {
            List<Item> listCart = _cartRepo.Get(HttpContext.Session);

            return PartialView(listCart);
        }
    }
}
