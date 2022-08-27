using BinhDinhFoodWeb.Intefaces;
using Microsoft.AspNetCore.Mvc;

namespace BinhDinhFoodWeb.Views.Product.Components.ProductRatingComponent
{
	public class ProductRatingComponent : ViewComponent
    {
        private readonly IProductRatingRepository _repo;
        public ProductRatingComponent(IProductRatingRepository repo)
        {
            _repo = repo;
        }
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var obj = await _repo.GetListAsync(filter: x=>x.ProductId == id);
            return View("ProductRatingComponent", obj);
        }
    }
}
