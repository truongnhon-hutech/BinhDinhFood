using BinhDinhFood.Models;
using BinhDinhFoodWeb.Intefaces;
using BinhDinhFoodWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace BinhDinhFoodWeb.Repositories
{
	public class BlogRepository : IBlogRepository
	{
		private readonly BinhDinhFoodDbContext _context;
		public BlogRepository(BinhDinhFoodDbContext context)
		{
			_context = context;
		}

		public async Task<Blog> Get(int id) => await _context.Blogs.FindAsync(id);

		public async Task<List<Blog>> GetAll() => await _context.Blogs.ToListAsync();
	}
}
