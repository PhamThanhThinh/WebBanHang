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
    //public IEnumerable<CartItemDto> ShoppingCartItems { get; set; }
    public List<CartItemDto> ShoppingCartItems { get; set; }
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

    protected async Task DeleteCartItem(int id)
    {
      try
      {
        var cartItemDto = await ShoppingCartService.DeleteItem(id);
        RemoveCartItem(id);
      }
      catch (Exception ex)
      {
        ErrorMessage = ex.Message;
      }
    }

    private CartItemDto GetCartItem(int id)
    {
      return ShoppingCartItems.FirstOrDefault(i => i.Id == id);
    }

    private void RemoveCartItem(int id)
    {
      var cartItemDto = GetCartItem(id);
      ShoppingCartItems.Remove(cartItemDto);
    }

  }
}
