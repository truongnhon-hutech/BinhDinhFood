using BinhDinhFood.Models;
using BinhDinhFoodWeb.Intefaces;
using Microsoft.EntityFrameworkCore;

namespace BinhDinhFoodWeb.Repositories
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {

        public CategoryRepository(BinhDinhFoodDbContext context): base(context)
        {
        }

        //public async Task<List<Category>> Get() 
        //    => await _context.Categories.ToListAsync();

        //public async Task<Category> GetById(int id) 
        //    => await _context.Categories.FindAsync(id);
    }
}
