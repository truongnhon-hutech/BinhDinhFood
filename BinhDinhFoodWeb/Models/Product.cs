using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BinhDinhFood.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId{ get; set; }
        [Required]
        [StringLength(100)]
        [DisplayName("Tên sản phẩm")]
        public string ProductName { get; set; }
        [DisplayName("Giá")]
        public double ProductPrice { get; set; }
        [DisplayName("Nội dung ")]
        public string ProductDescription { get; set; }
        [DisplayName("Số lượng")]
        public int ProductAmount { get; set; }
        [DisplayName("Khuyến mãi")]
        public int ProductDiscount { get; set; }
        [DisplayName("Hình ảnh")]
        public string ProductImage { get; set; }
        [DisplayName("Ngày thêm")]
        public DateTime ProductDateCreated { get; set; } = DateTime.Now;
        public Category Category { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
