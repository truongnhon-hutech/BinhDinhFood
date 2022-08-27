using BinhDinhFoodWeb.Models;

namespace BinhDinhFoodWeb.Intefaces
{
	public interface IProductRatingRepository
	{
		public Task<List<ProductRating>> GetAllProductRatingsAsync(int id);
		public Task<ProductRating> GetProductRatingAsync(int id);
		public void Save();
		public void Add(ProductRating pd);
	}
}
