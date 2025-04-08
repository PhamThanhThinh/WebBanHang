using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebBanHang.Api.Entities;
using WebBanHang.Api.Extensions;
using WebBanHang.Api.Repositories.Contracts;
using WebBanHang.Models.Dtos;

namespace WebBanHang.Api.Controllers
{
  // api/cart
  [Route("api/[controller]")]
  [ApiController]
  public class ShoppingCartController : ControllerBase
  {
    private readonly IShoppingCartRepository _shoppingCartRepository;
    private readonly IProductRepository _productRepository;

    public ShoppingCartController(IShoppingCartRepository shoppingCartRepository, IProductRepository productRepository)
    {
      _shoppingCartRepository = shoppingCartRepository;
      _productRepository = productRepository;
    }

    [HttpGet]
    [Route("{userId}/GetItems")]
    // load danh sách tất cả product (có thể lựa chọn thông tin cần load của một product)
    public async Task<ActionResult<IEnumerable<CartItemDto>>> GetItems(int userId)
    {
      // bắt exception
      // xử lý ngoại lệ
      try
      {
        var cartItems = await _shoppingCartRepository.GetItems(userId);
        if (cartItems == null)
        {
          //return NotFound();
          return NoContent();
        }
        //else
        //{

        //}

        var products = await _productRepository.GetItems();

        if (products == null)
        {
          throw new Exception("Không Có Sản Phẩm Nào");
        }
        var cartItemsDto = cartItems.ConvertToDto(products);
        return Ok(cartItemsDto);
      }
      catch (Exception ex)
      {
        return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
      }
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<CartItemDto>> GetItem(int id)
    {
      try
      {
        var cartItem = await _shoppingCartRepository.GetItem(id);
        if (cartItem == null)
        {
          return NotFound();
        }
        var product = await _productRepository.GetItem(cartItem.ProductId);

        if (product == null)
        {
          return NotFound();
        }

        var cartItemDto = cartItem.ConvertToDto(product);
        return Ok(cartItemDto);
      }
      catch (Exception ex)
      {
        return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
      }
    }
  }
}
