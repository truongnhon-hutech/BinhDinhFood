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
        // declare _repo but don't use
        private readonly ICartRepository _repo;
        public static List<Cart> listCartStatic = new List<Cart>();
        public CartController(ICartRepository repo)
        {
            _repo = repo;
        }
        public IActionResult Index()
        {
            List<Cart> listCart = GetAll();
            ViewData["TotalSubMoney"] = TotalMoney();
            ViewData["TotalMoney"] = 30000 + TotalMoney();

            Cart obj = new Cart() { dUnitPrice = 500, iProductId = 2, iQuantity = 2, sProductImage = "goica.png", sProductName = "nhon" };
            Cart obj1 = new Cart() { dUnitPrice = 1000, iProductId = 1, iQuantity = 2, sProductImage = "goica.png", sProductName = "nhondeptai" };
            listCart.Add(obj);
            listCart.Add(obj1);

            return View(listCart);
        }
        // get all product in cart
        public List<Cart> GetAll()
        {
            //Get data cart from session
            HttpContext.Session.SetString("Cart", JsonConvert.SerializeObject(listCartStatic));
            List<Cart> listCart = JsonConvert.DeserializeObject<List<Cart>>(HttpContext.Session.GetString("Cart"));
            return listCart;

        }
        // Add product to cart
        public IActionResult AddInCart(int id)
        {
            List<Cart> listCart = GetAll();
            Cart cart = listCart.FirstOrDefault(x => x.iProductId == id);
            if(cart == null)
            {
                cart = new Cart();
                listCart.Add(cart);
            }
            else
            {
                cart.iQuantity++;
            }
            return View(cart);
        }
        // sum all money 
        public double TotalMoney()
        {
            double totalMoney = 0;
            List<Cart> listCart = GetAll();
            if (listCart != null)
            {
                totalMoney = (double)listCart.Sum(x => x.dTotalMoney);
            }
            return totalMoney;
        }
        // remove product in cart
        public IActionResult RemoveInCart(int id) 
        {
            List<Cart> listCart = GetAll();
            Cart cart = listCart.SingleOrDefault(x => x.iProductId == id);
            if(cart != null)
            {
                listCart.RemoveAll(x=> x.iProductId ==id);
                return RedirectToAction("Cart");

            }
            return RedirectToAction("Cart");
        }
        // remove all product in cart
        public IActionResult RemoveAll()
        {
            List<Cart> listCart = GetAll();
            listCart.Clear();
            return RedirectToAction("Cart");
        }
        // Update Cart
            // ? update in form
        
        // Order - checkout
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
