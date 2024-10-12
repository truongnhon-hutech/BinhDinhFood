using BinhDinhFood.Models;

namespace BinhDinhFood.Intefaces;

public interface ICategoryRepository : IRepository<Category>
{
    //public Task<List<Category>> Get();
    //public Task<Category> GetById(int id);
    public Table[] GetRevenueStructure(int year);
}
