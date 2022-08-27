using BinhDinhFood.Models;
using BinhDinhFoodWeb.Intefaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace BinhDinhFoodWeb.Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {

        public ProductRepository(BinhDinhFoodDbContext context) :base(context)
        {
        }

        //public async Task<bool> CreateProductAsync(Product product)
        //{
        //    await _context.Products.AddAsync(product);
        //    return await SaveAsync();
        //}

        //public async Task<bool> DeleteProductAsync(Product product)
        //{
        //    _context.Products.Remove(product);
        //    return await SaveAsync();
        //}
        //public async Task<List<Product>> GetAllProductsAsync()
        //    => await _context.Products.ToListAsync();

        //public  List<Product> GetAllProductsDecending()
        //    => _context.Products.OrderByDescending(x => x.ProductId).Take(8).ToList();

        //public async Task<Product> GetProductByIdAsync(int id)
        //{
        //    Product? product = await _context.Products.FirstOrDefaultAsync(p => p.ProductId == id);
        //    if (product == null)
        //        return new Product();
        //    return product;
        //}

        //public async Task<bool> HasProductsAsync()
        //{
        //    return await _context.Products.AnyAsync();
        //}

        //public async Task<bool> SaveAsync()
        //{
        //    int saved = await _context.SaveChangesAsync();
        //    return saved > 0;
        //}

        //public async Task<List<Product>> SearchByFilter(string searchString)
        //{
        //    List<Product> obj = await _context.Products.Where(x => x.ProductName.Contains(searchString)).ToListAsync();
        //    return obj;
        //}

        //public async Task<bool> UpdateProductAsync(Product product)
        //{
        //    _context.Products.Update(product);
        //    return await SaveAsync();
        //}
    }
}
