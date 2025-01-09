using Test.Core.Models;
using Test.Core.Requests.Products;
using Test.Core.Responses;

namespace Test.Core.Handlers;

public interface IProductHandler
{
    Task<Response<Product?>> PostProductAsync(CreateProductRequest request);
    Task<Response<Product?>> UpdateProductAsync(UpdateProductRequest request);
    Task<Response<Product?>> DeleteProductAsync(DeleteProductRequest request);
    Task<Response<Product?>> GetByIdProductAsync(GetByIdProductRequest request);
    Task<Response<List<Product>?>> GetAllProductsAsync(GetAllProductsRequest request);
}