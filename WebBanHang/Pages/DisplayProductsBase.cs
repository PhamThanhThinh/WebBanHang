using Microsoft.AspNetCore.Components;
using WebBanHang.Models.Dtos;
using WebBanHang.Services.Contracts;

namespace WebBanHang.Pages
{
  public class DisplayProductsBase : ComponentBase
  {
    //[Inject]
    //public IProductService ProductService { get; set; }

    [Parameter]
    public IEnumerable<ProductDto> Products { get; set; }

    //protected override async Task OnInitializedAsync()
    //{
    //  Products = await ProductService.GetItems();
    //}
  }
}
