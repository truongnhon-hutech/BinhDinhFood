using BinhDinhFood.Models;
using System.ComponentModel;

namespace BinhDinhFoodWeb.Models
{
    public class Cart
    {
        private readonly BinhDinhFoodDbContext _db;
        public Cart(BinhDinhFoodDbContext db)
        {
            _db = db;
        }
        public int iProductId { set; get; }
        [DisplayName("Tên sản phẩm")]
        public string sProductName { set; get; }
        [DisplayName("Hình ảnh")]
        public string sProductImage { set; get; }
        [DisplayName("Đơn giá")]
        public Double dUnitPrice { set; get; }
        [DisplayName("Số lượng")]
        public int iQuantity { set; get; }
        [DisplayName("Tổng tiền")]
        public Double? dTotalMoney
        {
            get { return iQuantity * dUnitPrice; }
        }

        public Cart() { }

        public Cart(int ProductId)
        {
            iProductId = ProductId;
            Product product = _db.Products.Single(n => n.ProductId == iProductId);
            sProductName = product.ProductName;
            sProductImage = product.ProductImage;
            dUnitPrice = double.Parse(product.ProductPrice.ToString());
            iQuantity = 1;
        }
    }
}
