using BinhDinhFood.Models;
using BinhDinhFoodWeb.Intefaces;

namespace BinhDinhFoodWeb.Repositories
{
    public class OrderDetailRepository : RepositoryBase<OrderDetail>, IOrderDetailRepository
    {

    public OrderDetailRepository(BinhDinhFoodDbContext context) : base(context)
    {

    }
    }
}
