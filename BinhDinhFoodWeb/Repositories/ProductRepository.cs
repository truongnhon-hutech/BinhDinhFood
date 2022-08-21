using BinhDinhFood.Models;
using BinhDinhFoodWeb.Intefaces;
using Microsoft.EntityFrameworkCore;

namespace BinhDinhFoodWeb.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly BinhDinhFoodDbContext _context;

        public ProductRepository(BinhDinhFoodDbContext context)
        {
            _context = context;
        }

        public void AddProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public async Task<Product> GetProducts(int id)
        {
            return await _context.Products.FindAsync(id);
        }
        public async Task<List<Product>> GetAll()
        {
            return await _context.Products.Take(8).ToListAsync();
        }
    }
}
