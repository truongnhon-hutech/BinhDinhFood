using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BinhDinhFoodWeb.Models
{
    public class Discount {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Mã giảm giá")]
        public int DiscountId { get; set; }
        [DisplayName("Ngày khởi tạo")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DateStart { get; set; } = DateTime.Now;
        [DisplayName("Ngày kết thúc")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DateEnd { get; set; }
        [DisplayName("Phần trăm giảm")]
        public int DiscountPercent { get; set; }
        [DisplayName("Mô tả")]
        [StringLength(200)]
        public string? Description { get; set; }
        public virtual ICollection<DiscountDetail> DiscountDetails { get; set; }

    }
}
