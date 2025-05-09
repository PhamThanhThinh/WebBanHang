using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Threading.Tasks;
using WebBanHang.Models.Dtos;
using WebBanHang.Services.Contracts;

namespace WebBanHang.Pages.Checkout
{
  public class CheckoutBase : ComponentBase
  {
    // attribute
    [Inject]
    public IJSRuntime Js { get; set; }

    protected IEnumerable<CartItemDto> ShoppingCartItems { get; set; }

    protected int TotalQty { get; set; }
    protected string PaymentDescription {  get; set; }
    protected decimal PaymentAmount { get; set; }
    [Inject]
    public IShoppingCartService ShoppingCartService { get; set; }

    protected override async Task OnInitializedAsync()
    {
      try
      {
        ShoppingCartItems = await ShoppingCartService.GetItems(Hardcoded.UserId);

        if (ShoppingCartItems != null)
        {
          Guid orderGuid = Guid.NewGuid();
          //PaymentAmount = 0;
          PaymentAmount = ShoppingCartItems.Sum(p => p.TotalPrice);
          TotalQty = ShoppingCartItems.Sum(p => p.Qty);
          PaymentDescription = $"{Hardcoded.UserId}_{orderGuid}";
        }

      }
      catch (Exception)
      {

        throw;
      }
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
      try
      {
        if (firstRender)
        {
          await Js.InvokeVoidAsync("initPayPalButton");
        }
      }
      catch (Exception)
      {

        throw;
      }
    }



  }
}
