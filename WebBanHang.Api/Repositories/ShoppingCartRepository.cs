using Microsoft.EntityFrameworkCore;
using WebBanHang.Api.Data;
using WebBanHang.Api.Entities;
using WebBanHang.Api.Repositories.Contracts;
using WebBanHang.Models.Dtos;

namespace WebBanHang.Api.Repositories
{
  public class ShoppingCartRepository : IShoppingCartRepository
  {
    private readonly WebBanhangDbContext _db;

    public ShoppingCartRepository(WebBanhangDbContext db)
    {
      _db = db;
    }

    // xét nếu có item thì trả về true, nếu không có thì trả về false
    private async Task<bool> CarItemExists(int cartId, int productId)
    {
      return await _db.CartItems
        .AnyAsync(c => c.CartId == cartId && c.ProductId == productId);
    }

    public async Task<CartItem> AddItem(CartItemToAddDto cartItemToAddDto)
    {
      if (await CarItemExists(cartItemToAddDto.CartId, cartItemToAddDto.ProductId) == false)
      {
        var item = await (from product in _db.Products
                          where product.Id == cartItemToAddDto.ProductId
                          select new CartItem
                          {
                            CartId = cartItemToAddDto.CartId,
                            ProductId = product.Id,
                            Qty = cartItemToAddDto.Qty,
                          }).SingleOrDefaultAsync();

        if (item != null)
        {
          var ketQua = await _db.CartItems.AddAsync(item);
          await _db.SaveChangesAsync();
          return ketQua.Entity;
        }
      }

      return null;
    }

    public Task<CartItem> DeleteItem(int id)
    {
      throw new NotImplementedException();
    }

    // get thông tin của một item
    public async Task<CartItem> GetItem(int id)
    {
      return await (from cart in _db.Carts
                    join cartItem in _db.CartItems
                    on cart.Id equals cartItem.CartId
                    where cartItem.Id == id
                    select new CartItem
                    {
                      Id = cartItem.Id,
                      ProductId = cartItem.ProductId,
                      Qty = cartItem.Qty,
                      CartId = cartItem.CartId
                    }
                   ).SingleOrDefaultAsync();
    }
    // get tất cả item trong giỏ hàng
    public async Task<IEnumerable<CartItem>> GetItems(int userId)
    {
      return await (from cart in _db.Carts
                    join cartItem in _db.CartItems
                    on cart.Id equals cartItem.CartId
                    where cart.UserId == userId
                    select new CartItem
                    {
                      Id = cartItem.Id,
                      ProductId = cartItem.ProductId,
                      Qty = cartItem.Qty,
                      CartId = cartItem.CartId
                    }
                    ).ToListAsync();
    }

    public Task<CartItem> UpdateQty(int id, CartItemQtyUpdateDto cartItemQtyUpdateDto)
    {
      throw new NotImplementedException();
    }
  }
}
