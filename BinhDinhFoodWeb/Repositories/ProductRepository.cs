using BinhDinhFood.Models;
using BinhDinhFoodWeb.Intefaces;

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

        public Product GetProductById(int id)
        {
            return _context.Products.Find(id);
        }

        public List<Product> GetProducts()
        {
            return _context.Products.Take(8).ToList();
        }
    }
}
