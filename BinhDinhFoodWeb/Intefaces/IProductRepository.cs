using BinhDinhFood.Models;

namespace BinhDinhFoodWeb.Intefaces
{
    public interface IProductRepository
    {
        public List<Product> GetProducts();
        public Product GetProductById(int id);
        public void AddProduct(Product product);
    }
}
