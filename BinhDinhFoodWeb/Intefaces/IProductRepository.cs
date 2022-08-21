using BinhDinhFood.Models;

namespace BinhDinhFoodWeb.Intefaces
{
    public interface IProductRepository
    {
        public Task<List<Product>> GetAll();
        public Task<Product> GetProducts(int id);
        public void AddProduct(Product product);
    }
}
