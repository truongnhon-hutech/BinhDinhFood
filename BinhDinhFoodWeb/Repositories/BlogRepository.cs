using BinhDinhFood.Models;
using BinhDinhFoodWeb.Intefaces;
using BinhDinhFoodWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace BinhDinhFoodWeb.Repositories
{
	public class BlogRepository :RepositoryBase<Blog>, IBlogRepository
	{
		public BlogRepository(BinhDinhFoodDbContext context) : base(context){}
	}
}
