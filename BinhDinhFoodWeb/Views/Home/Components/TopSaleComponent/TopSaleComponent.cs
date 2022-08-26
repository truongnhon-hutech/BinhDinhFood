using BinhDinhFoodWeb.Intefaces;
using Microsoft.AspNetCore.Mvc;

namespace BinhDinhFoodWeb.Views.Home.Components.TopSaleComponent
{
    public class TopSaleComponent : ViewComponent
    {
        private readonly IProductRepository _repo;
        public TopSaleComponent(IProductRepository repo)
        {
            _repo = repo;
        }
        public async Task<IViewComponentResult> InvokeAsync() 
        { 
            var obj = _repo.GetAllProductsDecending();
            return View("TopSaleComponent", obj);
        }
    }
}
