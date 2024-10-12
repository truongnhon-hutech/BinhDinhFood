using BinhDinhFood.Intefaces;
using BinhDinhFood.Models;

namespace BinhDinhFood.Repositories;

public class FavoriteRepository : RepositoryBase<Favorite>, IFavoriteRepository
{
    public FavoriteRepository(BinhDinhFoodDbContext context) : base(context)
    {

    }
}
