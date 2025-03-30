using Microsoft.EntityFrameworkCore;
using WebBanHang.Api.Data;
using WebBanHang.Api.Entities;
using WebBanHang.Api.Repositories.Contracts;

namespace WebBanHang.Api.Repositories
{
  public class ProductRepository : IProductRepository
  {
    private readonly WebBanhangDbContext _dbContext;
    // contructor
    public ProductRepository(WebBanhangDbContext dbContext)
    {
      _dbContext = dbContext;
    }

    public async Task<IEnumerable<ProductCategory>> GetCategories()
    {
      var categories = await _dbContext.ProductCategories.ToListAsync();
      return categories;
    }

    public Task<ProductCategory> GetCategory(int id)
    {
      throw new NotImplementedException();
    }

    public Task<Product> GetItem(int id)
    {
      throw new NotImplementedException();
    }

    public async Task<IEnumerable<Product>> GetItems()
    {
      var products = await _dbContext.Products.ToListAsync();
      return products;
    }
  }
}
