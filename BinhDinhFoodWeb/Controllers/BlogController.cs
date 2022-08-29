using BinhDinhFoodWeb.Intefaces;
using BinhDinhFoodWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BinhDinhFoodWeb.Controllers
{
	public class BlogController: Controller
	{
		private readonly IBlogRepository _repo;
		public BlogController(IBlogRepository repo)
		{
			_repo = repo;
		}
		public async Task<IActionResult> Index()
		{
			var listBlog = await _repo.GetListAsync(orderBy: x=>x.OrderBy(x=>x.BlogId));
			return View(listBlog);
		}
		public async Task<IActionResult> BlogPost(int id)
		{
			 var post = await _repo.GetByIdAsync(id);
			return View(post);
		}

    }
}
