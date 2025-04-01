using WebBanHang.Models.Dtos;

namespace WebBanHang.Services.Contracts
{
  public interface IProductService
  {
    Task<IEnumerable<ProductDto>> GetItems();
    Task<ProductDto> GetItem(int id);
  }
}
