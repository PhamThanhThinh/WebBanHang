using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using WebBanHang.Models.Dtos;
using WebBanHang.Services.Contracts;

namespace WebBanHang.Services
{
  public class ShoppingCartService : IShoppingCartService
  {
    private readonly HttpClient _httpClient;

    public ShoppingCartService(HttpClient httpClient)
    {
      // this. gì đó
      _httpClient = httpClient;
    }

    public async Task<CartItemDto> AddItem(CartItemToAddDto cartItemToAddDto)
    {
      // xử lý ngoại lệ
      try
      {
        var shoppingCart = await _httpClient.PostAsJsonAsync<CartItemToAddDto>("api/ShoppingCart", cartItemToAddDto);

        if (shoppingCart.IsSuccessStatusCode)
        {
          if (shoppingCart.StatusCode == System.Net.HttpStatusCode.NoContent)
          {
            return default(CartItemDto);
          }

          return await shoppingCart.Content.ReadFromJsonAsync<CartItemDto>();
        }
        else
        {
          var messsage = await shoppingCart.Content.ReadAsStringAsync();
          throw new Exception($"Http Status: {shoppingCart.StatusCode} *** Message {messsage}");
        }
      }
      catch (Exception ex)
      {
        throw;
      }
    }

    public Task<IEnumerable<CartItemDto>> GetItems(int userId)
    {
      throw new NotImplementedException();
    }
  }
}
