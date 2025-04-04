﻿using WebBanHang.Api.Entities;
using WebBanHang.Models.Dtos;

namespace WebBanHang.Api.Extensions
{
  public static class DtoConversions
  {
    //public static IEnumerable<ProductDto> ConvertToDto(this IEnumerable<Product> products,
    //  IEnumerable<ProductCategory> productCategories)
    //{
    //  return (from product int products
    //    join productCategory in productCategories
    //    on product.CategoryId equals productCategory.Id
    //    select new ProductDto
    //    {

    //    }).ToList();
    //  //return (from product )
    //}
    public static IEnumerable<ProductDto> ConvertToDto(this IEnumerable<Product> products,
        IEnumerable<ProductCategory> productCategories)
    {
      return (from product in products
              join productCategory in productCategories
              on product.CategoryId equals productCategory.Id
              select new ProductDto
              {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                ImageURL = product.ImageURL,
                Price = product.Price,
                Qty = product.Qty,
                CategoryId = product.CategoryId,
                CategoryName = productCategory.Name,
                
              }).ToList();
    }

    public static ProductDto ConvertToDto(this Product product,
        ProductCategory productCategory)
    {
      //return (from product in products
      //        join productCategory in productCategories
      //        on product.CategoryId equals productCategory.Id
      //        select new ProductDto
      //        {
      //          Id = product.Id,
      //          Name = product.Name,
      //          Description = product.Description,
      //          ImageURL = product.ImageURL,
      //          Price = product.Price,
      //          Qty = product.Qty,
      //          CategoryId = product.CategoryId,
      //          CategoryName = productCategory.Name,

      //        }).ToList();
      return new ProductDto
      {
        Id = product.Id,
        Name = product.Name,
        Description = product.Description,
        ImageURL = product.ImageURL,
        Price = product.Price,
        Qty = product.Qty,
        CategoryId = product.CategoryId,
        CategoryName = productCategory.Name,
      };
    }
  }
}
