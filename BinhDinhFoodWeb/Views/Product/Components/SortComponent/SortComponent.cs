using BinhDinhFoodWeb.Intefaces;
using Microsoft.AspNetCore.Mvc;

namespace BinhDinhFoodWeb.Views.Product.Components.SortComponent
{
    public class SortComponent: ViewComponent
    {
        private readonly IProductRepository _repo;

        public SortComponent(IProductRepository repo)
        {
            _repo = repo;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
