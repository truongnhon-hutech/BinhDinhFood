using BinhDinhFoodWeb.Intefaces;
using Microsoft.AspNetCore.Mvc;

namespace BinhDinhFoodWeb.Views.Shared.Components.HeaderCategoryComponent
{
    public class HeaderCategoryComponent: ViewComponent
    {
        private readonly ICategoryRepository _repoCategory;

        public HeaderCategoryComponent(ICategoryRepository repoCategory)
        {
            _repoCategory = repoCategory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var obj = await _repoCategory.GetListAsync();
            return View(obj);
        }
    }
}
