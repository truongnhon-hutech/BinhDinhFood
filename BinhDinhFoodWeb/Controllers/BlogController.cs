using BinhDinhFoodWeb.Intefaces;
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
			var listBlog = await _repo.GetAll();
			return View();
		}
		public async Task<IActionResult> BlogPostAsync(int id)
		{
			var post = await _repo.Get(id);
			return View(post);
		}

    }
}
