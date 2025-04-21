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
    // chức năng Read
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

    // chức năng Create và Update
    [HttpPost]
    public async Task<ActionResult<CartItemDto>> PostItem([FromBody] CartItemToAddDto cartItemToAddDto)
    {
      // xử lý ngoại lệ
      // nếu không sẽ bị null và có nguy cơ dừng chương trình
      try
      {
        // tạo giỏ hàng bằng tay => phi thực tế
        // làm thế nào đó để tạo giỏ hàng tự động
        var newCartItem = await _shoppingCartRepository.AddItem(cartItemToAddDto);

        // check null
        if (newCartItem == null)
        {
          return NoContent();
        }

        var product = await _productRepository.GetItem(newCartItem.ProductId);

        if (product == null)
        {
          throw new Exception($"Không Có Sản Phẩm Nào (mã định danh của sản phẩm đó productId:({cartItemToAddDto.ProductId}))");
        }

        var newCartItemDto = newCartItem.ConvertToDto(product);

        return CreatedAtAction(nameof(GetItem), new { id = newCartItemDto.Id }, newCartItemDto);

      }
      catch (Exception ex)
      {
        return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
      }
    }

    [HttpDelete("{id:int}")]
    // dùng cho chức năng xóa Delete
    public async Task<ActionResult<CartItemDto>> DeleteItem(int id)
    {
      try
      {
        var cartItem = await _shoppingCartRepository.DeleteItem(id);
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
