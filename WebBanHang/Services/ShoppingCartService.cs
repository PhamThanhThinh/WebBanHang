using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Text;
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

    //public async Task<CartItemDto> UpdateQty(CartItemQtyUpdateDto cartItemQtyUpdateDto)
    //{
    //  try
    //  {
    //    var jsonRequest = JsonConvert.SerializeObject(cartItemQtyUpdateDto);
    //    var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json-patch+json");

    //    var response = await _httpClient.PatchAsync($"api/ShoppingCart/{cartItemQtyUpdateDto.CartItemId}", content);

    //    if (response.IsSuccessStatusCode)
    //    {
    //      return await response.Content.ReadFromJsonAsync<CartItemDto>();
    //    }
    //    return null;

    //  }
    //  catch (Exception)
    //  {
    //    //Log exception
    //    throw;
    //  }
    //}

    // cập nhật số lượng giỏ hàng
    public async Task<CartItemDto> UpdateQty(CartItemQtyUpdateDto cartItemQtyUpdateDto)
    {
      try
      {
        // vì chúng ta cần cập nhật một thành phần riêng trong một hàng dữ liệu trong một bảng dữ liệu
        var jsonRequest = JsonConvert.SerializeObject(cartItemQtyUpdateDto);
        // var noidung
        var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json-patch+json");

        // chứa id được từ DTO CartItemQtyUpdateDto
        var response = await _httpClient.PatchAsync("$api/ShoppingCart/{cartItemQtyUpdateDto.CartItemId}", content);

        // api trả về OK tức là 200
        if (response.IsSuccessStatusCode)
        {
          return await response.Content.ReadFromJsonAsync<CartItemDto>();
        }
        // 404 or 500
        return null;
      }
      catch (Exception)
      {
        // nhận message nếu có
        throw;
      }
    }

  }
}
