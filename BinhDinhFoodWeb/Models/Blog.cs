using BinhDinhFood.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BinhDinhFoodWeb.Models
{
    public class Blog
    {
        [Key]
        [DisplayName("Mã bài viết")]
        public int BlogId { get; set; }
        [Required]
        [DisplayName("Tên bài viết")]
        public String? BlogName { get; set; }
        [DisplayName("Nội dung")]
        public string? BlogContent { get; set; }
        [DisplayName("Hình ảnh")]
        public string? BlogImage {get; set;}
        [DisplayName("Ngày thêm")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BlogDateCreated { get; set; } = DateTime.Now;
    }
}
