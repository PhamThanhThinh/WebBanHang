using Microsoft.AspNetCore.Components;
using WebBanHang.Models.Dtos;
using WebBanHang.Services.Contracts;

namespace WebBanHang.Pages
{
  public class ProductsBase : ComponentBase
  {
    [Inject]
    public IProductService ProductService { get; set; }
    
    [Inject]
    public IShoppingCartService ShoppingCartService { get; set; }

    public IEnumerable<ProductDto> Products { get; set; }

    protected override async Task OnInitializedAsync()
    {
      try
      {
        Products = await ProductService.GetItems();

        var shoppingCartItems = await ShoppingCartService.GetItems(Hardcoded.UserId);
        // var tQ
        var totalQty = shoppingCartItems.Sum(i => i.Qty);

        ShoppingCartService.KichHoatSuKienTrangThaiCuaGioHang(totalQty);
      }
      catch (Exception)
      {

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
