using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace BinhDinhFoodWeb.Models
{
    public class RegisterViewModel
    {
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
        [Required]
        [StringLength(50)]
        [DisplayName("Nhập lại mật khẩu")]
        [Compare("CustomerPassword", ErrorMessage = "The password and confirmation password do not match.")]
        public string CustomerConfirmPassword { get; set; }
        [Required]
        [DisplayName("Email")]
        public string CustomerEmail { get; set; }
        [DisplayName("Địa chỉ")]
        public string CustomerAddress { get; set; }
    }
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Username")]
        public string CustomerUserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string CustomerPassword { get; set; }
        public bool RememberLogin { get; set; }
    }
    public class CookieUserItem
    {
        public int CustomerId { get; set; }
        public string CustomerUserName { get; set; }
        public string CustomerEmail { get; set; }
    }
    public class ForgotViewModel
    {
        [Required]
        [Display(Name="UserName")]
        public string CustomerUserName { get; set; }
        [Required]
        [Display(Name = "Email")]
        public string CustomerEmail { get; set; }
    }
    public class ResetViewModel
    {
        [Required]
        [Display(Name = "UserName")]
        public string CustomerUserName { get; set; }
        [Required]
        [StringLength(50)]
        [DisplayName("Mật khẩu")]
        public string CustomerPassword { get; set; }
        [Required]
        [StringLength(50)]
        [DisplayName("Nhập lại mật khẩu")]
        [Compare("CustomerPassword", ErrorMessage = "The password and confirmation password do not match.")]
        public string CustomerConfirmPassword { get; set; }
        [Required]
        public string Token { get; set; }
    }
    public class ChangeInforViewModel
    {
        [DisplayName("Họ tên")]
        public string CustomerFullName { get; set; }
        [DisplayName("Số điện thoại")]
        public string CustomerPhone { get; set; }
        [DisplayName("Email")]
        public string CustomerEmail { get; set; }
        [DisplayName("Địa chỉ")]
        public string CustomerAddress { get; set; }
        [DisplayName("Hình đại diện")]
        public string? CustomerImage { get; set; }
    }
    public class ChangePasswordViewModel
    {
        [Required]
        [StringLength(50)]
        [DisplayName("Mật khẩu cũ")]
        public string OldPassword { get; set; }
        [Required]
        [StringLength(50)]
        [DisplayName("Mật khẩu mới")]
        public string NewPassword { get; set; }
        [Required]
        [StringLength(50)]
        [DisplayName("Nhập lại mật khẩu mới")]
        [Compare("NewPassword", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
