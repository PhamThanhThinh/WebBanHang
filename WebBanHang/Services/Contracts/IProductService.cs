using WebBanHang.Models.Dtos;

namespace WebBanHang.Services.Contracts
{
  public interface IProductService
  {
    Task<IEnumerable<ProductDto>> GetItems();
  }
}
