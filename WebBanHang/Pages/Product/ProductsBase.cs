using Microsoft.AspNetCore.Components;
using WebBanHang.Models.Dtos;
using WebBanHang.Services.Contracts;

namespace WebBanHang.Pages.Product
{
  public class ProductsBase : ComponentBase
  {
    [Inject]
    public IProductService ProductService { get; set; }
    
    [Inject]
    public IShoppingCartService ShoppingCartService { get; set; }

    public IEnumerable<ProductDto> Products { get; set; }

    public string ErrorMessage { get; set; }

    protected override async Task OnInitializedAsync()
    {
      try
      {
        Products = await ProductService.GetItems();

        var shoppingCartItems = await ShoppingCartService.GetItems(Hardcoded.UserId);
        // var tQ tổng số lượng
        var totalQty = shoppingCartItems.Sum(i => i.Qty);

        // RaiseEventOnShoppingCartChanged
        ShoppingCartService.KichHoatSuKienTrangThaiCuaGioHang(totalQty);

      }
      catch (Exception ex)
      {
        ErrorMessage = ex.Message;
        throw;
      }
    }

    protected IOrderedEnumerable<IGrouping<int, ProductDto>> GetGroupedProductsByCategory()
    {
      return from product in Products
             group product by product.CategoryId into producByCategory
             orderby producByCategory.Key
             select producByCategory;
    }

    protected string GetCategoryName(IGrouping<int, ProductDto> productDtos)
    {
      return productDtos.FirstOrDefault(product => product.CategoryId == productDtos.Key).CategoryName;
    }


  }
}
