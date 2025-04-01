using System.Net.Http.Json;
using WebBanHang.Models.Dtos;
using WebBanHang.Services.Contracts;

namespace WebBanHang.Services
{
  public class ProductService : IProductService
  {
    private readonly HttpClient _httpClient;

    public ProductService(HttpClient httpClient)
    {
      _httpClient = httpClient;
    }

    public async Task<IEnumerable<ProductDto>> GetItems()
    {
      try
      {
        //var products = await _httpClient.GetFromJsonAsync<IEnumerable<ProductDto>>("api/Product");
        //var products = await _httpClient.GetFromJsonAsync<IEnumerable<ProductDto>>("https://localhost:7097/api/Product");
        var products = await _httpClient.GetAsync("https://localhost:7097/api/Product");
        //return products;

        if (products.IsSuccessStatusCode)
        {
          if (products.StatusCode == System.Net.HttpStatusCode.NoContent)
          {
            return Enumerable.Empty<ProductDto>();
          }

          return await products.Content.ReadFromJsonAsync<IEnumerable<ProductDto>>();
        }
        else
        {
          var message = await products.Content.ReadAsStringAsync();
          throw new Exception(message);
        }

      }
      catch (Exception)
      {
        // log error
        throw;
      }
    }

    public async Task<ProductDto> GetItem(int id)
    {
      try
      {
        var product = await _httpClient.GetAsync($"https://localhost:7097/api/Product/{id}");
        //var product = await _httpClient.GetAsync($"https://localhost:7097/api/Product/0");

        if (product.IsSuccessStatusCode)
        {
          if (product.StatusCode == System.Net.HttpStatusCode.NoContent)
          {
            return default(ProductDto);
          }

          return await product.Content.ReadFromJsonAsync<ProductDto>();
        }
        else
        {
          var message = await product.Content.ReadAsStringAsync();
          throw new Exception(message);
        }
      }
      catch (Exception)
      {
        // log error
        throw;
      }
    }

  }
}
