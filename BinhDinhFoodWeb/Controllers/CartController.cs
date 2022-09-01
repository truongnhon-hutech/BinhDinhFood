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
        private readonly ICustomerRepository _customerRepo;
        private readonly IOrderRepository _orderRepo;
        private readonly IOrderDetailRepository _orderDetailRepo;
        private double shippingCost = 30000;
        public CartController(ICartRepository cartRepo, IProductRepository productRepo, ICustomerRepository customerRepo, IOrderDetailRepository orderDetailRepo, IOrderRepository orderRepo)
        {
            _cartRepo = cartRepo;
            _productRepo = productRepo;
            _customerRepo = customerRepo;
            _orderRepo = orderRepo;
            _orderDetailRepo = orderDetailRepo;
        }
        public IActionResult Index()
        {
            List<Item> listCart = _cartRepo.Get(HttpContext.Session);
            ViewData["TotalSubMoney"] = TotalMoney().ToString("#,###", cul.NumberFormat); ;
            ViewData["ShippingCost"] = shippingCost.ToString("#,###", cul.NumberFormat); ;
            ViewData["TotalMoney"] = (shippingCost + TotalMoney()).ToString("#,###", cul.NumberFormat); ;

            return View(listCart);
        }
        public IActionResult UpdateCart()
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Login", "User");
            List<Item> cart = _cartRepo.Get(HttpContext.Session);
            ViewData["TotalSubMoney"] = TotalMoney().ToString("#,###", cul.NumberFormat);
            ViewData["ShippingCost"] = shippingCost.ToString("#,###", cul.NumberFormat);
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
        public async Task<IActionResult> Order()
        {
            if(!User.Identity.IsAuthenticated)
                return RedirectToAction("Login", "User");
            
            List<Item> listCart = _cartRepo.Get(HttpContext.Session);
            
            int id = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            Customer customer = await _customerRepo.GetByIdAsync(id);
            ViewBag.Name = customer.CustomerFullName;
            ViewBag.Phone= customer.CustomerPhone;
            ViewBag.Address = customer.CustomerAddress;
            ViewBag.Email = customer.CustomerEmail;

            if (listCart == null)
                return RedirectToAction("Order", "Cart");
            
            ViewData["TotalSubMoney"] = TotalMoney().ToString("#,###", cul.NumberFormat);
            ViewData["ShippingCost"] = shippingCost.ToString("#,###", cul.NumberFormat);
            ViewData["TotalMoney"] = (shippingCost + TotalMoney()).ToString("#,###", cul.NumberFormat);

            return View(listCart);
        }
        [HttpPost]
        public async Task<IActionResult> Order(IFormCollection form)
        {
            int id = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            Customer customer = await _customerRepo.GetByIdAsync(id);
            List<Item> listCart = _cartRepo.Get(HttpContext.Session);
            
            Order or = new Order();
            or.CustomerId = id;
            or.DayOrder = DateTime.Now;
            or.DayDelivery = DateTime.Now.AddDays(3);
            or.PaidState = true;
            // build payment momo or vnpay
            or.DeliveryState = false;
            or.TotalMoney = shippingCost + TotalMoney();
            await _orderRepo.AddAsync(or);
            await _orderRepo.SaveAsync();

            foreach(var item in listCart)
            {
                OrderDetail detail = new OrderDetail();
                detail.OrderId = or.OrderId;
                detail.ProductId = item.Product.ProductId;
                detail.Quantity = item.Quantity;
                detail.UnitPrice = Convert.ToDecimal(item.Product.ProductPrice);
                await _orderDetailRepo.AddAsync(detail);
                await _orderDetailRepo.SaveAsync();
            }
            // clear cart
            _cartRepo.Set(HttpContext.Session, new List<Item>());
            return RedirectToAction("Comfirm");
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
        public async Task<IActionResult> TrackOrderAsync()
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Login");
            int id = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));

            IEnumerable<Order> obj = await _orderRepo.GetListAsync(filter: x => x.CustomerId == id);
            return View(obj);
        }

        public async Task<IActionResult> OderDetail(int id)
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Login");
            IEnumerable<OrderDetail> obj = await _orderDetailRepo.GetListAsync(filter: x => x.OrderId == id, includeProperties:"Product");
            return View(obj);
        }
    }
}
