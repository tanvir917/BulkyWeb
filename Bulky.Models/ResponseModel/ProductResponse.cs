using System;
using Bulky.Models.ViewModels;

namespace Bulky.Models.ResponseModel
{
    public class ProductResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ISBN { get; set; }
        public string Author { get; set; }
        public double ListPrice { get; set; }
        public double Price { get; set; }
        public double Price50 { get; set; }
        public double Price100 { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public string ImageUrl { get; set; }
        public override bool Equals(object? obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (obj.GetType() != typeof(ProductResponse))
            {
                return false;
            }
            ProductResponse product_to_compare = (ProductResponse)obj;
            return this.Title == product_to_compare.Title;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
    public static class ProductExtensions
    {
        public static ProductResponse ToProductResponse(this Product product)
        {
            return new ProductResponse()
            {
                Id = product.Id,
                Title = product.Title,
                Description = product.Description,
                ISBN = product.ISBN,
                Author = product.Author,
                ListPrice = product.ListPrice,
                Price = product.Price,
                Price50 = product.Price50,
                Price100 = product.Price100,
                CategoryId = product.CategoryId,
                Category = product.Category,
                ImageUrl = product.ImageUrl,
            };
        }
    }
}

