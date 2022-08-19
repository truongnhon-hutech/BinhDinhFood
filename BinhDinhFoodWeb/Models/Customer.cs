using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BinhDinhFood.Models
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerId { get; set; }
        [DisplayName("Họ tên")]
        public string CustomerFullName { get; set; }
        [Required]
        [StringLength(50)]
        [DisplayName("Tài khoản")]
        public string CustomerUserName { get; set; }
        [Required]
        [StringLength(50)]
        [DisplayName("Mật khẩu")]
        public string CustomerPassword { get; set; }    
        [DisplayName("Ngày khởi tạo")]
        public DateTime CustomerDateCreated { get; set; } = DateTime.Now;
        [DisplayName("Email")]
        public string CustomerEmail { get; set; }
        [DisplayName("Địa chỉ")]
        public string CustomerAddress { get; set; }
        [DisplayName("Trạng thái")]
        public bool CustomerState { get; set; }
        [DisplayName("Hình đại diện")]
        public string CustomerImage { get; set; }
        public ICollection<Order> Orders { get; set; }

    }
}
