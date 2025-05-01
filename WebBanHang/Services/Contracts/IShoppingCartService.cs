using WebBanHang.Models.Dtos;

namespace WebBanHang.Services.Contracts
{
  public interface IShoppingCartService
  {
    // khai báo các method cần dùng
    // vừa khai báo, vừa được được gọi từ method khác
    Task<List<CartItemDto>> GetItems(int userId);
    Task<CartItemDto> AddItem(CartItemToAddDto cartItemToAddDto);
    Task<CartItemDto> DeleteItem(int id);
    Task<CartItemDto> UpdateQty(CartItemQtyUpdateDto cartItemQtyUpdateDto);

    event Action<int> TrangThaiGioHang;
    void KichHoatSuKienTrangThaiCuaGioHang(int totalQty);

  }
}
