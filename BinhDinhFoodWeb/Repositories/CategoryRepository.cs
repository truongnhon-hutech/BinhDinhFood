using BinhDinhFood.Models;
using BinhDinhFoodWeb.Intefaces;
using Microsoft.EntityFrameworkCore;

namespace BinhDinhFoodWeb.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly BinhDinhFoodDbContext _context;

        public CategoryRepository(BinhDinhFoodDbContext context)
        {
            _context = context;
        }

        public async Task<List<Category>> Get() 
            => await _context.Categories.ToListAsync();

        public async Task<Category> GetById(int id) 
            => await _context.Categories.FindAsync(id);
    }
}
