using Microsoft.AspNetCore.Components;
using WebBanHang.Models.Dtos;
using WebBanHang.Services.Contracts;

namespace WebBanHang.Pages
{
  public class ProductsBase : ComponentBase
  {
    [Inject]
    public IProductService ProductService { get; set; }

    public IEnumerable<ProductDto> Products { get; set; }

    protected override async Task OnInitializedAsync()
    {
      Products = await ProductService.GetItems();
    }
  }
}
