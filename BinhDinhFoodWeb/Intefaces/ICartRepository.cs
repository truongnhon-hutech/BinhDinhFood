using BinhDinhFoodWeb.Models;

namespace BinhDinhFoodWeb.Intefaces
{
    public interface ICartRepository
    {
        public Task<List<Cart>> GetAll();
        public Task<List<Cart>> Get(int id);
    }
}
