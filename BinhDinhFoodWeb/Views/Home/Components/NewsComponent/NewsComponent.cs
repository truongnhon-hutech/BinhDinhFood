using BinhDinhFoodWeb.Intefaces;
using Microsoft.AspNetCore.Mvc;

namespace BinhDinhFoodWeb.Views.Home.Components.NewsComponent
{
    public class NewsComponent: ViewComponent
    {
        private readonly IProductRepository _repo;
        public NewsComponent(IProductRepository repo)
        {
            _repo = repo;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var obj = await _repo.GetListAsync(take: 2);
            return View("NewComponent", obj);
        }
    }
}
