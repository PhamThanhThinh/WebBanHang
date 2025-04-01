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

    public async Task<ProductCategory> GetCategory(int id)
    {
      var category = await _dbContext.ProductCategories.SingleOrDefaultAsync(i => i.Id == id);
      return category;
    }

    // load thông tin chi tiết sản phẩm
    // làm trang chi tiết sản phẩm
    public async Task<Product> GetItem(int id)
    {
      var product = await _dbContext.Products.FindAsync(id);
      return product;
    }

    // load tất cả sản phẩm
    // load sản phẩm theo danh mục sản phẩm
    // làm trang chủ
    public async Task<IEnumerable<Product>> GetItems()
    {
      var products = await _dbContext.Products.ToListAsync();
      return products;
    }
  }
}
