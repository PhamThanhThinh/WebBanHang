using WebBanHang.Api.Entities;

namespace WebBanHang.Api.Repositories.Contracts
{
  public interface IProductRepository
  {
    // get tất cả sản phẩm trong giỏ hàng
    Task<IEnumerable<Product>> GetItems();
    // get tất cả danh mục sản phẩm (lên trang chủ)
    Task<IEnumerable<ProductCategory>> GetCategories();
    // get từng sản phẩm trong giỏ hàng
    Task<Product> GetItem(int id);
    // get từng danh mục sản phẩm
    Task<ProductCategory> GetCategory(int id);
  }
}
