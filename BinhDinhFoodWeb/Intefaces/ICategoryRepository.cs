using BinhDinhFood.Models;

namespace BinhDinhFoodWeb.Intefaces
{
    public interface ICategoryRepository
    {
        public Task<List<Category>> Get();
        public Task<Category> GetById(int id);
    }
}
