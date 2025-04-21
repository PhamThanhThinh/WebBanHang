using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;
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
          // 204 NoContent
          if (shoppingCart.StatusCode == System.Net.HttpStatusCode.NoContent)
          {
            //return Enumerable.Empty<CartItemDto>(); dòng code này sai vì không trả về danh sách
            return default(CartItemDto);
            //return null;
          }
          // 202 OK
          return await shoppingCart.Content.ReadFromJsonAsync<CartItemDto>();
        }
        else
        {
          var messsage = await shoppingCart.Content.ReadAsStringAsync();
          throw new Exception($"Http Status: {shoppingCart.StatusCode} *** Message {messsage}");
        }
      }
      catch (Exception)
      {
        throw;
      }
    }

    public async Task<CartItemDto> DeleteItem(int id)
    {
      try
      {
        var response = await _httpClient.DeleteAsync($"api/ShoppingCart/{id}");

        if (response.IsSuccessStatusCode)
        {
          return await response.Content.ReadFromJsonAsync<CartItemDto>();
        }
        return default(CartItemDto);
      }
      catch (Exception ex)
      {

        throw;
      }
    }

    public async Task<List<CartItemDto>> GetItems(int userId)
    {
      try
      {
        var response = await _httpClient.GetAsync($"api/ShoppingCart/{userId}/GetItems");
        if (response.IsSuccessStatusCode)
        {
          if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
          {
            return Enumerable.Empty<CartItemDto>().ToList();
          }
          var items = await response.Content.ReadFromJsonAsync<List<CartItemDto>>();
          return items;
        }
        else
        {
          var message = await response.Content.ReadAsStringAsync();
          //throw new Exception(message);
          throw new Exception($"Http status code: {response.StatusCode} *** Message: {message}");
        }
      }
      catch (Exception)
      {
        throw;
      }
    }

    public Task<CartItemDto> UpdateItem(CartItemToAddDto cartItemToAddDto)
    {
      throw new NotImplementedException();
    }

    //public Task<CartItemDto> UpdateItem(CartItemToAddDto cartItemToAddDto)
    //{
    //  try
    //  {
    //    var jsonRequest = JsonConvert.Serial
    //  }
    //  catch (Exception)
    //  {

    //    throw;
    //  }
    //}
  }
}
