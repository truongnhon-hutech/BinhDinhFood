using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BinhDinhFood.Models
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set; }
        [DisplayName("Ngày đặt hàng")]
        public DateTime DayOrder { get; set; }
        [DisplayName("Ngày vận chuyển")]
        public DateTime DayDelivery { get; set; }
        [DisplayName("Đã trả tiền")]
        public bool PaidState { get; set; }
        [DisplayName("Trạng thái đơn hàng")]
        public bool DeliveryState { get; set; }
        [DisplayName("Tổng tiền")]
        public double TotalMoney { get; set; }
        public Customer Customer { get; set; }
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

    }
}
