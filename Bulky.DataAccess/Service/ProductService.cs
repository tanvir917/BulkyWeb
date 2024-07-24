using System;
using System.Diagnostics.Metrics;
using Bulky.DataAccess.Service.IService;
using Bulky.Models;
using Bulky.Models.InputModel;
using Bulky.Models.ResponseModel;

namespace Bulky.DataAccess.Service
{
    public class ProductService : IProductService
    {
        private readonly List<Product> _products;
        public ProductService()
        {
            _products = new List<Product>();
        }

        public ProductResponse AddProduct(ProductAddRequest? productAddRequest)
        {
            //Validation: productAddRequest parameter can't be null
            if (productAddRequest == null)
            {
                throw new ArgumentNullException(nameof(productAddRequest));
            }

            //Validation: productName can't be null
            if (productAddRequest.Title == null)
            {
                throw new ArgumentException(nameof(productAddRequest.Title));
            }

            //Validation: productName can't be duplicate
            if (_products.Where(temp => temp.Title == productAddRequest.Title).Count() > 0)
            {
                throw new ArgumentException("Given product name already exists");
            }

            //Convert object from productAddRequest to product type
            Product product = productAddRequest.ToProduct();
            Random rnd = new Random();
            product.Id = rnd.Next(1, 100);
            //Add product object into _products
            _products.Add(product);

            return product.ToProductResponse();
        }
        public List<ProductResponse> GetAllProducts()
        {
            return _products.Select(country => country.ToProductResponse()).ToList();
        }

        public ProductResponse? GetProductById(int? id)
        {
            if (id == null)
                return null;

            Product? country_response_from_list = _products.FirstOrDefault(temp => temp.Id == id);

            if (country_response_from_list == null)
                return null;

            return country_response_from_list.ToProductResponse();
        }
    }
}

