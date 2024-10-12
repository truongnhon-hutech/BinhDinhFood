using BinhDinhFood.Intefaces;
using BinhDinhFood.Models;

namespace BinhDinhFood.Repositories;

public class OrderDetailRepository : RepositoryBase<OrderDetail>, IOrderDetailRepository
{

    public OrderDetailRepository(BinhDinhFoodDbContext context) : base(context)
    {

    }
}
