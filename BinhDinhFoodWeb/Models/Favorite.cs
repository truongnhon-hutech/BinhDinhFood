using BinhDinhFood.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BinhDinhFoodWeb.Models
{
    public class Favorite
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Mã sản phẩm yêu thích")]
        public int FavoriteId { get; set; }
        [DisplayName("Ngày thêm")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime PRDateCreated { get; set; } = DateTime.Now;
        [DisplayName("Mã sản phẩm")]
        public int ProductId { get; set; }
        [DisplayName("Mã khách hàng")]
        public int CustomerId { get; set; }
        public Product? Product { get; set; }
        public Customer? Customer { get; set; }
    }
}
