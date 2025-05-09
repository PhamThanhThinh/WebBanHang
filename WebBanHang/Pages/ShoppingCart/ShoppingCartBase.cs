using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Runtime.CompilerServices;
using WebBanHang.Models.Dtos;
using WebBanHang.Services.Contracts;

namespace WebBanHang.Pages.ShoppingCart
{
  public class ShoppingCartBase : ComponentBase
  {
    [Inject]
    public IJSRuntime Js { get; set; }
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
        //CalculateCartSummaryTotals();
        CartChagned();
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
        //CalculateCartSummaryTotals();
        CartChagned();
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
      TotalPrice = ShoppingCartItems.Sum(p => p.TotalPrice).ToString("C");
    }
    private void SetTotalQuantiy()
    {
      TotalQuantity = ShoppingCartItems.Sum(p => p.Qty);
    }

    private void UpdateItemTotalPrice(CartItemDto cartItemDto)
    {
      var item = GetCartItem(cartItemDto.Id);

      if (item != null)
      {
        // tổng tiền = số lượng x đơn giá
        item.TotalPrice = cartItemDto.Price * cartItemDto.Qty;
      }
      
      //await 

    }

    private void CalculateCartSummaryTotals()
    {
      // nếu có sự thay đổi về tổng của giá trị trong giỏ hàng
      // thì thay đổi luôn
      // còn không thì load dữ liệu ban đầu ra
      SetTotalPrice();
      SetTotalQuantiy();
    }

    private void CartChagned()
    {
      CalculateCartSummaryTotals();
      ShoppingCartService.KichHoatSuKienTrangThaiCuaGioHang(TotalQuantity);
    }

    protected async Task UpdateQtyCartItem(int id, int qty)
    {
      try
      {
        if (qty > 0)
        {
          var updateItemDto = new CartItemQtyUpdateDto
          {
            CartItemId = id,
            Qty = qty
          };

          var returnedUpdateItemDto = await ShoppingCartService.UpdateQty(updateItemDto);

          UpdateItemTotalPrice(returnedUpdateItemDto);

          // không thể truyền trực tiếp vào đây
          //CalculateCartSummaryTotals();
          CartChagned();

          // cách làm trên là cơ bản

          // tính năng update qty nâng cao

          // gọi một method ở đây, method này chưa được code
          //await 

          await MakeUpdateQtyCartItem(id, false);
          // hiển thị nút cập nhật giỏ hàng cho người ta
          // vì đa số hàng trên hệ thống còn tồn kho
          //await MakeUpdateQtyCartItem(id, true);
        }
        else
        {
          var item = ShoppingCartItems.FirstOrDefault(i => i.Id == id);

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

    // nút update số lượng hàng có được hiện lên không
    // ẩn hiện nút cập nhật số lượng hàng (làm trước) / ẩn hiện sản phẩm (làm sau)
    private async Task MakeUpdateQtyCartItem(int id, bool visible)
    {
      await Js.InvokeVoidAsync("MakeUpdateQtyCartItem", id, visible);
    }

    //protected IEnumerable<CartItemDto> ShoppingCartItems { get; set; }

    protected int TotalQty { get; set; }
    protected string PaymentDescription { get; set; }
    protected decimal PaymentAmount { get; set; }

  }
}
