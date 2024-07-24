
namespace Bulky.Models.InputModel
{
    public class ProductAddRequest
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

        public Product ToProduct()
        {
            return new Product()
            {
                Id = Id,
                Title = Title,
                Description = Description,
                ISBN = ISBN,
                Author = Author,
                ListPrice = ListPrice,
                Price = Price,
                Price50 = Price50,
                Price100 = Price100,
                CategoryId = CategoryId,
                Category = Category,
                ImageUrl = ImageUrl,
            };
        }
    }
}

