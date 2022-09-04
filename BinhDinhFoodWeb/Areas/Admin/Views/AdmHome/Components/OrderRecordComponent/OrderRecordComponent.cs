using BinhDinhFood.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BinhDinhFoodWeb.Areas.Admin.Views.AdmHome.Components.OrderRecordComponent
{
    public class OrderRecordComponent : ViewComponent
    {
        private BinhDinhFoodDbContext _context;

        public OrderRecordComponent(BinhDinhFoodDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            //var x = new OrderRecordViewModel
            //{
            //    OrderId = orderId,
            //    CustomerName = (order.Customer != null) ? order.Customer.CustomerFullName : "Undefined",
            //    ProductName = "Nothing",
            //    TotalMoney = (double)((order.OrderDetails != null) ? order.OrderDetails.Sum(od => od.Quantity * od.Product.ProductPrice) : 0)
            //};
            // Get recent order list
            var result = await _context.OrderDetails.OrderByDescending(od => od.Order.DayOrder).Select(o => new OrderRecordViewModel
            {
                OrderId = o.OrderId,
                CustomerName = (o.Order.Customer != null) ? o.Order.Customer.CustomerFullName : "Undefined",
                ProductName = (o.Product != null) ? (string)o.Product.ProductName : "Undefined",
                TotalMoney = (double)((o.Order.OrderDetails != null) ? o.Order.OrderDetails.Sum(od => od.Quantity * od.Product.ProductPrice) : 0),
                Status = (o.Order.PaidState) ? "Đã thanh toán" : (o.Order.DeliveryState) ? "Đang đợi giao hàng" : "Đã bị từ chối"
            }).ToListAsync();
            return View(result);
        }
    }

    public class OrderRecordViewModel
    {
        public int OrderId { get; set; }
        public string CustomerName { get; set; }
        public string ProductName { get; set; }
        public double TotalMoney { get; set; }
        public string Status { get; set; }
    }
}


