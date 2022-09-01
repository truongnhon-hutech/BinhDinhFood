using BinhDinhFood.Models;
using BinhDinhFoodWeb.Intefaces;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.Globalization;

namespace BinhDinhFoodWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdmHomeController : Controller
    {

        private readonly BinhDinhFoodDbContext _context;
        CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");

        public AdmHomeController(BinhDinhFoodDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(string saleOrder, string revenueOrder, string customerOrder)
        {
            if (saleOrder == null)
                saleOrder = "today";
            if (revenueOrder == null)
                revenueOrder = "today";
            if (customerOrder == null)
                customerOrder = "today";

            int objSale = 0;
            switch (saleOrder)
            {
                case "today":
                    objSale = _context.Orders.Where(
                        x => x.DayOrder.Day == DateTime.Now.Day
                        && x.DayOrder.Month == DateTime.Now.Month
                        && x.DayOrder.Year == DateTime.Now.Year
                        ).Count();

                    ViewBag.SalePercent = objSale / (objSale + (objSale / 3)) * 100;
                    ViewBag.SaleDay = "Hôm nay";
                    break;
                case "thisMonth":
                    objSale = _context.Orders.Where(
                        x => x.DayOrder.Year == DateTime.Now.Year
                        && x.DayOrder.Month == DateTime.Now.Month
                        ).Count();
                    ViewBag.SaleDay = "Tháng này";
                    ViewBag.SalePercent = objSale / (objSale + (objSale / 3)) * 100;
                    break;
                case "thisYear":
                    objSale = _context.Orders.Where(x => x.DayOrder.Year == DateTime.Now.Year).Count();
                    ViewBag.SaleDay = "Năm này";
                    ViewBag.SalePercent = objSale / (objSale + (objSale / 3)) * 100;
                    break;
            }
            ViewBag.SaleNumbers = objSale;

            double objRevenue = 0;
            switch (revenueOrder)
            {
                case "today":
                    objRevenue = _context.Orders.Where(
                        x => x.DayOrder.Day == DateTime.Now.Day
                        && x.DayOrder.Month == DateTime.Now.Month
                        && x.DayOrder.Year == DateTime.Now.Year
                        ).Sum(x => x.TotalMoney);
                    ViewBag.RevenuePercent = Math.Round((objRevenue / (objRevenue + objRevenue / 2) * 100), 2);
                    ViewBag.RevenueDay = "Hôm nay";
                    break;
                case "thisMonth":
                    objRevenue = _context.Orders.Where(
                        x => x.DayOrder.Year == DateTime.Now.Year
                        && x.DayOrder.Month == DateTime.Now.Month
                        ).Sum(x => x.TotalMoney);
                    ViewBag.RevenueDay = "Tháng này";
                    ViewBag.RevenuePercent = Math.Round((objRevenue / (objRevenue + objRevenue / 2) * 100), 2);
                    break;
                case "thisYear":
                    objRevenue = _context.Orders.Where(x => x.DayOrder.Year == DateTime.Now.Year).Sum(x => x.TotalMoney);
                    ViewBag.RevenueDay = "Năm này";
                    ViewBag.RevenuePercent = Math.Round((objRevenue / (objRevenue + objRevenue / 2) * 100), 2);
                    break;
            }
            ViewBag.RevenueNumbers = objRevenue.ToString("#,###", cul.NumberFormat);

            int objCustomer = 0;
            switch (customerOrder)
            {
                case "today":
                    objCustomer = _context.Customers.Where(
                        x => x.CustomerDateCreated.Day == DateTime.Now.Day
                        && x.CustomerDateCreated.Month == DateTime.Now.Month
                        && x.CustomerDateCreated.Year == DateTime.Now.Year
                        ).Count();
                    ViewBag.CustomerPercent = (objCustomer);
                    ViewBag.CustomerDay = "Hôm nay";
                    break;
                case "thisMonth":
                    objCustomer = _context.Customers.Where(
                        x => x.CustomerDateCreated.Year == DateTime.Now.Year
                        && x.CustomerDateCreated.Month == DateTime.Now.Month
                        ).Count();
                    ViewBag.CustomerDay = "Tháng này";
                    ViewBag.CustomerPercent = (objCustomer);
                    break;
                case "thisYear":
                    objCustomer = _context.Customers.Where(x => x.CustomerDateCreated.Year == DateTime.Now.Year).Count();
                    ViewBag.CustomerDay = "Năm này";
                    ViewBag.CustomerPercent = (objCustomer);
                    break;
            }
            ViewBag.CustomerNumbers = objCustomer;

            var saleChart1 = _context.Orders.Where(
                        x => x.DayOrder.Month >= 1 && x.DayOrder.Month <= 4
                        && x.DayOrder.Year == DateTime.Now.Year
                        ).Count();
            var saleChart2 = _context.Orders.Where(
                        x => x.DayOrder.Month >= 4 && x.DayOrder.Month <= 8
                        && x.DayOrder.Year == DateTime.Now.Year
                        ).Count();
            var saleChart3 = _context.Orders.Where(
                        x => x.DayOrder.Month >= 8 && x.DayOrder.Month <= 12
                        && x.DayOrder.Year == DateTime.Now.Year
                        ).Count();
            ViewBag.saleChart1 = saleChart1;
            ViewBag.saleChart2 = saleChart2;
            ViewBag.saleChart3 = saleChart3;

            var revenueChart1 = _context.Orders.Where(
                       x => x.DayOrder.Month >= 1 && x.DayOrder.Month <= 4
                       && x.DayOrder.Year == DateTime.Now.Year
                       ).Sum(x => x.TotalMoney);
            var revenueChart2 = _context.Orders.Where(
                        x => x.DayOrder.Month >= 4 && x.DayOrder.Month <= 8
                        && x.DayOrder.Year == DateTime.Now.Year
                        ).Sum(x => x.TotalMoney);
            var revenueChart3 = _context.Orders.Where(
                        x => x.DayOrder.Month >= 8 && x.DayOrder.Month <= 12
                        && x.DayOrder.Year == DateTime.Now.Year
                        ).Sum(x => x.TotalMoney);
            ViewBag.revenueChart1 = revenueChart1 / 100000;
            ViewBag.revenueChart2 = revenueChart2 / 100000;
            ViewBag.revenueChart3 = revenueChart3 / 100000;

            var customerChart1 = _context.Customers.Where(
                        x => x.CustomerDateCreated.Month >= 1 && x.CustomerDateCreated.Month <= 4
                        && x.CustomerDateCreated.Year == DateTime.Now.Year
                        ).Count();
            var customerChart2 = _context.Customers.Where(
                        x => x.CustomerDateCreated.Month >= 4 && x.CustomerDateCreated.Month <= 8
                        && x.CustomerDateCreated.Year == DateTime.Now.Year
                        ).Count();
            var customerChart3 = _context.Customers.Where(
                        x => x.CustomerDateCreated.Month >= 8 && x.CustomerDateCreated.Month <= 12
                        && x.CustomerDateCreated.Year == DateTime.Now.Year
                        ).Count();
            ViewBag.customerChart1 = customerChart1;
            ViewBag.customerChart2 = customerChart2;
            ViewBag.customerChart3 = customerChart3;
            return View();
        }
    }
}
