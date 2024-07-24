using System;
using Bulky.DataAccess.Data;
using Bulky.DataAccess.Repository;
using Bulky.DataAccess.Repository.IRepository;
using Bulky.DataAccess.Service;
using Bulky.DataAccess.Service.IService;
using Bulky.Models.InputModel;
using Bulky.Models.ResponseModel;

namespace Bulky.Test
{
    public class ProductServiceTest
    {
        private readonly IProductService _productService;
        public ProductServiceTest()
        {
            _productService = new ProductService();
        }
        [Fact]
        public void AddProduct_NullProduct()
        {
            //Arrange
            ProductAddRequest? request = null;
            //Assert
            Assert.Throws<ArgumentNullException>(() =>
            {
                //Act
                _productService.AddProduct(request);
            });
        }
        [Fact]
        public void AddProduct_DuplicateTitle()
        {
            //Arrange
            ProductAddRequest? request1 = new ProductAddRequest()
            {
                Title = "USA"
            };
            ProductAddRequest? request2 = new ProductAddRequest()
            {
                Title = "USA"
            };
            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                //act
                _productService.AddProduct(request1);
                _productService.AddProduct(request2);
            });
        }
        [Fact]
        public void AddProduct_ProperProductDetails()
        {
            //Arrange
            ProductAddRequest? request = new ProductAddRequest()
            {
                Title = "Japan"
            };
            //Act
            ProductResponse response = _productService.AddProduct(request);
            List<ProductResponse> products_from_getAllProducts = _productService.GetAllProducts();
            //Assert
            //Assert.True(response.Id != 0);
            Assert.Contains(response, products_from_getAllProducts);
        }

        #region GetAllCountries

        [Fact]
        //The list of countries should be empty by default (before adding any countries)
        public void GetAllCountries_EmptyList()
        {
            //Act
            List<ProductResponse> actual_Product_response_list = _productService.GetAllProducts();

            //Assert
            Assert.Empty(actual_Product_response_list);
        }

        [Fact]
        public void GetAllCountries_AddFewCountries()
        {
            //Arrange
            List<ProductAddRequest> Product_request_list = new List<ProductAddRequest>() {
                new ProductAddRequest() { Title = "USA" },
                new ProductAddRequest() { Title = "UK" }
              };

            //Act
            List<ProductResponse> countries_list_from_add_Product = new List<ProductResponse>();

            foreach (ProductAddRequest Product_request in Product_request_list)
            {
                countries_list_from_add_Product.Add(_productService.AddProduct(Product_request));
            }

            List<ProductResponse> actualProductResponseList = _productService.GetAllProducts();

            //read each element from countries_list_from_add_Product
            foreach (ProductResponse expected_Product in countries_list_from_add_Product)
            {
                Assert.Contains(expected_Product, actualProductResponseList);
            }
        }
        #endregion

        #region GetProductById
        [Fact]
        public void GetProductById_NullProductId()
        {
            //Arrange
            int Id = 0;
            //Act
            ProductResponse product_response_from_get_method = _productService.GetProductById(Id);
            //Assert
            Assert.Null(product_response_from_get_method);
        }
        [Fact]
        public void GetProductById_ValidProductId()
        {
            //Arrange
            ProductAddRequest? product_add_request = new ProductAddRequest()
            {
                Title = "USA",
            };
            ProductResponse product_response_from_add = _productService.AddProduct(product_add_request);
            //Act
            ProductResponse? product_response_from_get =
            _productService.GetProductById(product_response_from_add.Id);

            //Assert
            Assert.Equal(product_response_from_add, product_response_from_get);
        }
        #endregion
    }
}

