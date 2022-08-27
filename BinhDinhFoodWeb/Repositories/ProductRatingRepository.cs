using BinhDinhFood.Models;
using BinhDinhFoodWeb.Intefaces;
using BinhDinhFoodWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace BinhDinhFoodWeb.Repositories
{
	public class ProductRatingRepository : IProductRatingRepository
	{
        private readonly BinhDinhFoodDbContext _context;

        public ProductRatingRepository(BinhDinhFoodDbContext context)
        {
            _context = context;
        }
        public async Task<ProductRating> GetProductRatingAsync(int id) 
            => await _context.ProductRatings.FindAsync(id);
        public async Task<List<ProductRating>> GetAllProductRatingsAsync(int id) 
            => await _context.ProductRatings
                .Where(x => x.ProductId == id)
                .ToListAsync();

        public void Save()=> _context.SaveChanges();

        public void Add(ProductRating pd) => _context.ProductRatings.Add(pd);
    }
}
