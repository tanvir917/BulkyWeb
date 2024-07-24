using System;
using Bulky.Models.InputModel;
using Bulky.Models.ResponseModel;

namespace Bulky.DataAccess.Service.IService
{
    public interface IProductService
    {
        ProductResponse AddProduct(ProductAddRequest? productAddRequest);
        List<ProductResponse> GetAllProducts();
        ProductResponse? GetProductById(int? id);
    }
}

