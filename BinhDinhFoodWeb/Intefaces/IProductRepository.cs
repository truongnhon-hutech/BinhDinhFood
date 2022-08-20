using BinhDinhFood.Models;

namespace BinhDinhFoodWeb.Intefaces
{
    public interface IProductRepository
    {
        public Task<List<Product>> GetProducts();
        public Task<Product> GetProductById(int id);
        public void AddProduct(Product product);
    }
}
