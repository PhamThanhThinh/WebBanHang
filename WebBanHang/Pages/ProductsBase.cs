using Microsoft.AspNetCore.Components;
using WebBanHang.Models.Dtos;
using WebBanHang.Services.Contracts;

namespace WebBanHang.Pages
{
  public class ProductsBase : ComponentBase
  {
    [Inject]
    public IProductService ProductService { get; set; }

    public IEnumerable<ProductDto> Products { get; set; }

    protected override async Task OnInitializedAsync()
    {
      Products = await ProductService.GetItems();
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
