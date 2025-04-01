using Microsoft.AspNetCore.Components;
using WebBanHang.Models.Dtos;
using WebBanHang.Services.Contracts;

namespace WebBanHang.Pages
{
  public class ProductDetailsBase : ComponentBase
  {
    [Parameter]
    public int Id { get; set; }
    [Inject]
    public IProductService ProductService { get; set; }
    public ProductDto Product { get; set; }
    public string ErrorMessage { get; set; }

    protected override async Task OnInitializedAsync()
    {
      try
      {
        Product = await ProductService.GetItem(Id);
      }
      catch (Exception ex)
      {
        ErrorMessage = ex.Message;
      }
    }
  }
}
