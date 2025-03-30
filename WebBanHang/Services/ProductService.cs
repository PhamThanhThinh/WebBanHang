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
        var products = await _httpClient.GetFromJsonAsync<IEnumerable<ProductDto>>("https://localhost:7097/api/Product");
        return products;
      }
      catch (Exception)
      {
        // log error
        throw;
      }
    }
  }
}
