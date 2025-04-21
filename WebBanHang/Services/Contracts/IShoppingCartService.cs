﻿using WebBanHang.Models.Dtos;

namespace WebBanHang.Services.Contracts
{
  public interface IShoppingCartService
  {
    Task<List<CartItemDto>> GetItems(int userId);
    Task<CartItemDto> AddItem(CartItemToAddDto cartItemToAddDto);
    Task<CartItemDto> DeleteItem(int id);
    Task<CartItemDto> UpdateItem(CartItemToAddDto cartItemToAddDto);
  }
}
