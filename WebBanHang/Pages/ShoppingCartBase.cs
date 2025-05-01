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

    protected async Task UpdateQtyCartItem(int id, int qty)
    {
      try
      {
        if (qty > 0)
        {
          var cartItemDto = new CartItemQtyUpdateDto
          {
            CartItemId = id,
            Qty = qty
          };

          var returnedUpdateItemDto = await this.ShoppingCartService.UpdateQty(cartItemDto);

        }
        else
        {
          var item = this.ShoppingCartItems.FirstOrDefault(i => i.Id == id);

          // is not null
          // ! =
          if (item != null)
          {
            // hardcoding
            item.Qty = 1;
            item.TotalPrice = item.Price;
          }

        }

      }
      catch (Exception)
      {

        throw;
      }

    }

  }
}
