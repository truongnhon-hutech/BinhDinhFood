using BinhDinhFood.Intefaces;
using BinhDinhFood.Models;
using BinhDinhFood.Models.Entities;

namespace BinhDinhFood.Repositories;

public class BannerRepository : RepositoryBase<Banner>, IBannerRepository
{
    public BannerRepository(BinhDinhFoodDbContext context) : base(context)
    {

    }
}
