using BinhDinhFood.Models;
using BinhDinhFoodWeb.Intefaces;
using BinhDinhFoodWeb.Models;

namespace BinhDinhFoodWeb.Repositories
{
    public class BannerRepository : RepositoryBase<Banner>, IBannerRepository
    {
        public BannerRepository(BinhDinhFoodDbContext context): base(context)
        {

        }
    }
}
