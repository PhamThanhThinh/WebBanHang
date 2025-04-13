using Microsoft.AspNetCore.Components;
using WebBanHang.Models.Dtos;
using WebBanHang.Services.Contracts;

namespace WebBanHang.Pages
{
  public class ShoppingCartBase : ComponentBase
  {
    // đây là một attribute
    [Inject]
    public IShoppingCartService ShoppingCartService { get; set; }
    public IEnumerable<CartItemDto> ShoppingCartItems { get; set; }
    public string ErrorMessage { get; set; }
    protected override async Task OnInitializedAsync()
    {
      try
      {
        ShoppingCartItems = await ShoppingCartService.GetItems(Hardcoded.UserId);
      }
      catch (Exception ex)
      {
        ErrorMessage = ex.Message;
      }
    }

  }
}
