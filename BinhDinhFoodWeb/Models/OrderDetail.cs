using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BinhDinhFood.Models
{
    public class OrderDetail
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int OrderId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProductId { get; set; }

        [Column(TypeName = "money")]
        public decimal? UnitPrice { get; set; }

        public int? Quantity { get; set; }

        public virtual Order Order { get; set; }

        public virtual Product Product { get; set; }

    }
}
