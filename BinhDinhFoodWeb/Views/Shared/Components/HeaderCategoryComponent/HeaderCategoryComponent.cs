using BinhDinhFoodWeb.Intefaces;
using Microsoft.AspNetCore.Mvc;

namespace BinhDinhFoodWeb.Views.Shared.Components.HeaderCategoryComponent
{
    public class HeaderCategoryComponent: ViewComponent
    {
        private readonly ICategoryRepository _repoCategory;
        private readonly IProductRepository _repoProduct;

        public HeaderCategoryComponent(ICategoryRepository repoCategory, IProductRepository productRepository)
        {
            _repoCategory = repoCategory;
            _repoProduct = productRepository;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewBag.category1 = await _repoProduct.GetListAsync(filter: x => x.CategoryId == 1, take: 6);
            ViewBag.category2 = await _repoProduct.GetListAsync(filter: x => x.CategoryId == 6, take: 6);
            ViewBag.category3 = await _repoProduct.GetListAsync(filter: x => x.CategoryId == 7, take: 6);
            return View();
        }
    }
}
