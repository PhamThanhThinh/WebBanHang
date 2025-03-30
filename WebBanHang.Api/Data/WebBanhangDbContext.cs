using Microsoft.EntityFrameworkCore;
using WebBanHang.Api.Entities;

namespace WebBanHang.Api.Data
{
  public class WebBanhangDbContext : DbContext
  {
    public WebBanhangDbContext(DbContextOptions options) : base(options)
    {
    }



    //protected WebBanhangDbContext()
    //{
    //}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      // seed data
      // product
      modelBuilder.Entity<Product>().HasData( new Product
      {
        Id = 1,
        Name = "Doctor Who: Once Upon A Time Lord",
        Description = "In order to survive the fiery Pyromeths, Martha Jones must spin three sensational yarns about the Tenth Doctor and his greatest adventures with old and new foes alike!",
        ImageURL = "/Images/Comic/91oVGuZABHL._SL1500_.jpg",
        Price = 16,
        Qty = 50,
        CategoryId = 1
      });
      modelBuilder.Entity<Product>().HasData(new Product
      {
        Id = 2,
        Name = "Doctor Who: Once Upon A Time Lord",
        Description = "In order to survive the fiery Pyromeths, Martha Jones must spin three sensational yarns about the Tenth Doctor and his greatest adventures with old and new foes alike!",
        ImageURL = "/Images/Comic/91oVGuZABHL._SL1500_.jpg",
        Price = 16,
        Qty = 50,
        CategoryId = 1
      });
      modelBuilder.Entity<Product>().HasData(new Product
      {
        Id = 3,
        Name = "Doctor Who: Once Upon A Time Lord",
        Description = "In order to survive the fiery Pyromeths, Martha Jones must spin three sensational yarns about the Tenth Doctor and his greatest adventures with old and new foes alike!",
        ImageURL = "/Images/Comic/91oVGuZABHL._SL1500_.jpg",
        Price = 16,
        Qty = 50,
        CategoryId = 1
      });
      modelBuilder.Entity<Product>().HasData(new Product
      {
        Id = 4,
        Name = "Doctor Who: Once Upon A Time Lord",
        Description = "In order to survive the fiery Pyromeths, Martha Jones must spin three sensational yarns about the Tenth Doctor and his greatest adventures with old and new foes alike!",
        ImageURL = "/Images/Comic/91oVGuZABHL._SL1500_.jpg",
        Price = 16,
        Qty = 50,
        CategoryId = 1
      });
      modelBuilder.Entity<Product>().HasData(new Product
      {
        Id = 5,
        Name = "Doctor Who: Once Upon A Time Lord",
        Description = "In order to survive the fiery Pyromeths, Martha Jones must spin three sensational yarns about the Tenth Doctor and his greatest adventures with old and new foes alike!",
        ImageURL = "/Images/Comic/91oVGuZABHL._SL1500_.jpg",
        Price = 16,
        Qty = 50,
        CategoryId = 1
      });
      modelBuilder.Entity<Product>().HasData(new Product
      {
        Id = 6,
        Name = "Doctor Who: Once Upon A Time Lord",
        Description = "In order to survive the fiery Pyromeths, Martha Jones must spin three sensational yarns about the Tenth Doctor and his greatest adventures with old and new foes alike!",
        ImageURL = "/Images/Comic/91oVGuZABHL._SL1500_.jpg",
        Price = 16,
        Qty = 50,
        CategoryId = 1
      });
      modelBuilder.Entity<Product>().HasData(new Product
      {
        Id = 7,
        Name = "Doctor Who: Once Upon A Time Lord",
        Description = "In order to survive the fiery Pyromeths, Martha Jones must spin three sensational yarns about the Tenth Doctor and his greatest adventures with old and new foes alike!",
        ImageURL = "/Images/Comic/91oVGuZABHL._SL1500_.jpg",
        Price = 16,
        Qty = 50,
        CategoryId = 1
      });
      modelBuilder.Entity<Product>().HasData(new Product
      {
        Id = 8,
        Name = "Doctor Who: Once Upon A Time Lord",
        Description = "In order to survive the fiery Pyromeths, Martha Jones must spin three sensational yarns about the Tenth Doctor and his greatest adventures with old and new foes alike!",
        ImageURL = "/Images/Comic/91oVGuZABHL._SL1500_.jpg",
        Price = 16,
        Qty = 50,
        CategoryId = 1
      });
      modelBuilder.Entity<Product>().HasData(new Product
      {
        Id = 9,
        Name = "Doctor Who: Once Upon A Time Lord",
        Description = "In order to survive the fiery Pyromeths, Martha Jones must spin three sensational yarns about the Tenth Doctor and his greatest adventures with old and new foes alike!",
        ImageURL = "/Images/Comic/91oVGuZABHL._SL1500_.jpg",
        Price = 16,
        Qty = 50,
        CategoryId = 1
      });
      modelBuilder.Entity<Product>().HasData(new Product
      {
        Id = 10,
        Name = "Doctor Who: Once Upon A Time Lord",
        Description = "In order to survive the fiery Pyromeths, Martha Jones must spin three sensational yarns about the Tenth Doctor and his greatest adventures with old and new foes alike!",
        ImageURL = "/Images/Comic/91oVGuZABHL._SL1500_.jpg",
        Price = 16,
        Qty = 50,
        CategoryId = 1
      });
      modelBuilder.Entity<Product>().HasData(new Product
      {
        Id = 11,
        Name = "Doctor Who: Once Upon A Time Lord",
        Description = "In order to survive the fiery Pyromeths, Martha Jones must spin three sensational yarns about the Tenth Doctor and his greatest adventures with old and new foes alike!",
        ImageURL = "/Images/Comic/91oVGuZABHL._SL1500_.jpg",
        Price = 16,
        Qty = 50,
        CategoryId = 1
      });
      // user
      modelBuilder.Entity<User>().HasData(new User
      {
        Id = 1,
        UserName = "a"
      });
      modelBuilder.Entity<User>().HasData(new User
      {
        Id = 2,
        UserName = "b"
      });

      // giỏ hàng cart
      modelBuilder.Entity<Cart>().HasData(new Cart
      {
        Id = 1,
        UserId = 1
      });
      modelBuilder.Entity<Cart>().HasData(new Cart
      {
        Id = 2,
        UserId = 2
      });

      // danh mục sản phẩm ProductCategory
      modelBuilder.Entity<ProductCategory>().HasData(new ProductCategory
      {
        Id = 1,
        Name = "Comic"
      });
      modelBuilder.Entity<ProductCategory>().HasData(new ProductCategory
      {
        Id = 2,
        Name = "Electronic"
      });
    }


    public DbSet<Cart> Carts { get; set; }
    public DbSet<CartItem> CartItems { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductCategory> ProductCategories { get; set; }
    public DbSet<User> Users { get; set; }
  }
}
