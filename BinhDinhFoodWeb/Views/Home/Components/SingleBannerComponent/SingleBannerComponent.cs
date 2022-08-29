using BinhDinhFoodWeb.Intefaces;
using Microsoft.AspNetCore.Mvc;

namespace BinhDinhFoodWeb.Views.Home.Components.SingleBannerComponent
{
    public class SingleBannerComponent: ViewComponent
    {
        private readonly IBannerRepository _repo;

        public SingleBannerComponent(IBannerRepository repo)
        {
            _repo = repo;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var obj = await _repo.GetByIdAsync(10);
            return View("SingleBannerComponent", obj);
        }
    }
}
