using BinhDinhFood.Intefaces;
using BinhDinhFood.Models;

namespace BinhDinhFood.Repositories;

public class BlogRepository : RepositoryBase<Blog>, IBlogRepository
{
    public BlogRepository(BinhDinhFoodDbContext context) : base(context) { }
}
