using BinhDinhFood.Models;
using BinhDinhFoodWeb.Intefaces;
using BinhDinhFoodWeb.Models;

namespace BinhDinhFoodWeb.Repositories
{
	public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
		public CustomerRepository(BinhDinhFoodDbContext context) : base(context)
		{

		}
	}
}
