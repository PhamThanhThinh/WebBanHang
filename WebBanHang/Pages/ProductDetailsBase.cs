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
    [Inject]
    public NavigationManager NavigationManager { get; set; }

    [Inject]
    public IShoppingCartService ShoppingCartService { get; set; }

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

    // code chức năng thêm giỏ hàng
    protected async Task AddToCart(CartItemToAddDto cartItemToAddDto)
    {
      try
      {
        var cartItemDto = await ShoppingCartService.AddItem(cartItemToAddDto);
        NavigationManager.NavigateTo("/ShoppingCart");
      }
      catch (Exception ex)
      {
        ErrorMessage = ex.Message;
      }
    }
  }
}
