using BinhDinhFoodWeb.Models;

namespace BinhDinhFoodWeb.Intefaces
{
	public interface IBlogRepository
	{
		public Task<List<Blog>> GetAll();	
		public Task<Blog> Get(int id);
	}
}
