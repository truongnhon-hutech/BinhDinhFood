using BinhDinhFood.Models;
using BinhDinhFoodWeb.Intefaces;

namespace BinhDinhFoodWeb.Repositories
{
	public class OrderRepository: RepositoryBase<Order>, IOrderRepository
    {
		public OrderRepository(BinhDinhFoodDbContext context): base(context)
		{

		}
	}
}
