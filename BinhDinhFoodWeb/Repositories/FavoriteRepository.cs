using BinhDinhFood.Models;
using BinhDinhFoodWeb.Intefaces;
using BinhDinhFoodWeb.Models;

namespace BinhDinhFoodWeb.Repositories
{
    public class FavoriteRepository: RepositoryBase<Favorite>, IFavoriteRepository
    {
        public FavoriteRepository(BinhDinhFoodDbContext context) : base(context)
        {

        }
    }
}
