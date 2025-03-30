using System.ComponentModel.DataAnnotations;

namespace WebBanHang.Api.Entities
{
  public class CartItem
  {
    [Key]
    public int Id { get; set; }
    public int CartId { get; set; }
    public int ProductId { get; set; }
    // Quantity số lượng
    public int Qty { get; set; }
  }
}
