using BinhDinhFood.Models;

namespace BinhDinhFoodWeb.Intefaces
{
    public interface IProductRepository
    {
        public Task<List<Product>> GetAllProductsAsync();
        public Task<List<Product>> SearchByFilter(string searchString);
        public List<Product> GetAllProductsDecending();
        public Task<Product> GetProductByIdAsync(int id);
        public Task<bool> CreateProductAsync(Product product);
        public Task<bool> UpdateProductAsync(Product product);
        public Task<bool> DeleteProductAsync(Product product);
        public Task<bool> HasProductsAsync();
        public Task<bool> SaveAsync();
    }
}
