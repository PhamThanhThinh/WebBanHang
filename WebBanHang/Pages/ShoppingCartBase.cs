using Microsoft.AspNetCore.Components;
using System.Runtime.CompilerServices;
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
    
    protected string TotalPrice { get; set; }
    protected int TotalQuantity {  get; set; }

    protected override async Task OnInitializedAsync()
    {
      try
      {
        ShoppingCartItems = await ShoppingCartService.GetItems(Hardcoded.UserId);
        
        // tính tổng giá tiền
        //UpdateItemTotalPrice();
        CalculateCartSummaryTotals();
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
        //UpdateItemTotalPrice();
        CalculateCartSummaryTotals();
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

    private void SetTotalPrice()
    {
      TotalPrice = this.ShoppingCartItems.Sum(p => p.TotalPrice).ToString("C");
    }
    private void SetTotalQuantiy()
    {
      TotalQuantity = this.ShoppingCartItems.Sum(p => p.Qty);
    }

    private void UpdateItemTotalPrice(CartItemDto cartItemDto)
    {
      var item = GetCartItem(cartItemDto.Id);

      if (item != null)
      {
        // tổng tiền = số lượng x đơn giá
        item.TotalPrice = cartItemDto.Price * cartItemDto.Qty;
      }
    }

    private void CalculateCartSummaryTotals()
    {
      SetTotalPrice();
      SetTotalQuantiy();
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

          UpdateItemTotalPrice(returnedUpdateItemDto);

          // không thể truyền trực tiếp vào đây
          CalculateCartSummaryTotals();
        }
        else
        {
          var item = this.ShoppingCartItems.FirstOrDefault(i => i.Id == id);

          // is not null
          // ! =
          if (item != null)
          {
            // hardcoding: code cứng
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
