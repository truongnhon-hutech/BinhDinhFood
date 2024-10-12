using BinhDinhFood.Intefaces;
using BinhDinhFood.Models;
using BinhDinhFood.Models.Entities;

namespace BinhDinhFood.Repositories;

public class FavoriteRepository : RepositoryBase<Favorite>, IFavoriteRepository
{
    public FavoriteRepository(BinhDinhFoodDbContext context) : base(context)
    {

    }
}
