using BinhDinhFood.Models;
using BinhDinhFoodWeb.Intefaces;
using BinhDinhFoodWeb.Models;

namespace BinhDinhFoodWeb.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly BinhDinhFoodDbContext _context;
        public CartRepository(BinhDinhFoodDbContext context)
        {
            _context = context;
        }

        public Task<List<Cart>> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Cart>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
