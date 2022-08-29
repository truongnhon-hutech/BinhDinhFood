using BinhDinhFoodWeb.Intefaces;
using Microsoft.AspNetCore.Mvc;

namespace BinhDinhFoodWeb.Views.Shared.Components.HeaderCategoryComponent
{
    public class HeaderCategoryComponent: ViewComponent
    {
        private readonly ICategoryRepository _repo;

        public HeaderCategoryComponent(ICategoryRepository repo)
        {
            _repo = repo;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var obj = await _repo.GetListAsync();
            return View(obj);
        }
    }
}
