using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Test.Core.Handlers;
using Test.Core.Models;
using Test.Core.Requests.Products;
using Test.Core.Responses;
using Test.MinimalApi.Data;

namespace Test.MinimalApi.Handlers;

public class ProductHandler(TestDbContext context) : IProductHandler
{
    public async Task<Response<Product?>> PostProductAsync(CreateProductRequest request)
    {
        try
        {
            var product = new Product
            {
                UserId = request.UserId,
                Title = request.Title,
                Price = request.Price,
                Type = request.Type,
            };
            
            await context.Products.AddAsync(product);
            await context.SaveChangesAsync();
            
            return new Response<Product?>(product, 201, "Produto criado com sucesso!");
        }
        catch (ArgumentNullException)
        {
            // Exceção para dados nulos
            return new Response<Product?>(null, 400, "Requisição inválida.");
        }
        catch (DbUpdateException)
        {
            // Erro ao tentar salvar no banco de dados
            return new Response<Product?>(null, 500, "Erro ao salvar no banco de dados.");
        }
        catch (InvalidOperationException)
        {
            // Operação inválida
            return new Response<Product?>(null, 500, "Erro interno no servidor.");
        }
        catch (SqlException)
        {
            // Erro específico de SQL (se usar SQL Server)
            return new Response<Product?>(null, 500, "Erro no banco de dados.");
        }
        catch (Exception)
        {
            // Exceção genérica para capturar qualquer erro inesperado
            return new Response<Product?>(null, 500, "Erro desconhecido.");
        }
    }

    public async Task<Response<Product?>> UpdateProductAsync(UpdateProductRequest request)
    {
        try
        {
            var product = await context
                .Products
                .FirstOrDefaultAsync(x => x.Id == request.Id && x.UserId == request.UserId);

            if (product == null)
                return new Response<Product?>(null, 404, "Produto nao encontrado.");
            
            product.Title = request.Title;
            product.Price = request.Price;
            product.Type = request.Type;
            
            context.Products.Update(product);
            await context.SaveChangesAsync();
            
            return new Response<Product?>(product, 200, "Produto atualizado com sucesso!");
        }
        catch (ArgumentNullException)
        {
            // Exceção para dados nulos
            return new Response<Product?>(null, 400, "Requisição inválida.");
        }
        catch (DbUpdateException)
        {
            // Erro ao tentar salvar no banco de dados
            return new Response<Product?>(null, 500, "Erro ao salvar no banco de dados.");
        }
        catch (InvalidOperationException)
        {
            // Operação inválida
            return new Response<Product?>(null, 500, "Erro interno no servidor.");
        }
        catch (SqlException)
        {
            // Erro específico de SQL (se usar SQL Server)
            return new Response<Product?>(null, 500, "Erro no banco de dados.");
        }
        catch (Exception)
        {
            // Exceção genérica para capturar qualquer erro inesperado
            return new Response<Product?>(null, 500, "Erro desconhecido.");
        }
    }

    public async Task<Response<Product?>> DeleteProductAsync(DeleteProductRequest request)
    {
        try
        {
            var product = await context
                .Products
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == request.Id && x.UserId == request.UserId);
            
            if (product == null)
                return new Response<Product?>(null, 404, "Produto nao encontrado.");
            
            context.Products.Remove(product);
            await context.SaveChangesAsync();
            
            return new Response<Product?>(product, 200, "Produto deletado com sucesso!");
        }
        catch (ArgumentNullException)
        {
            // Exceção para dados nulos
            return new Response<Product?>(null, 400, "Requisição inválida.");
        }
        catch (DbUpdateException)
        {
            // Erro ao tentar salvar no banco de dados
            return new Response<Product?>(null, 500, "Erro ao salvar no banco de dados.");
        }
        catch (InvalidOperationException)
        {
            // Operação inválida
            return new Response<Product?>(null, 500, "Erro interno no servidor.");
        }
        catch (SqlException)
        {
            // Erro específico de SQL (se usar SQL Server)
            return new Response<Product?>(null, 500, "Erro no banco de dados.");
        }
        catch (Exception)
        {
            // Exceção genérica para capturar qualquer erro inesperado
            return new Response<Product?>(null, 500, "Erro desconhecido.");
        }
    }

    public async Task<Response<Product?>> GetByIdProductAsync(GetByIdProductRequest request)
    {
        try
        {
            var product = await context
                .Products
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == request.Id && x.UserId == request.UserId);
            
            if (product == null)
                return new Response<Product?>(null, 404, "Produto nao encontrado.");
            
            return new Response<Product?>(product);
        }
        catch (ArgumentNullException)
        {
            // Exceção para dados nulos
            return new Response<Product?>(null, 400, "Requisição inválida.");
        }
        catch (DbUpdateException)
        {
            // Erro ao tentar salvar no banco de dados
            return new Response<Product?>(null, 500, "Erro ao salvar no banco de dados.");
        }
        catch (InvalidOperationException)
        {
            // Operação inválida
            return new Response<Product?>(null, 500, "Erro interno no servidor.");
        }
        catch (SqlException)
        {
            // Erro específico de SQL (se usar SQL Server)
            return new Response<Product?>(null, 500, "Erro no banco de dados.");
        }
        catch (Exception)
        {
            // Exceção genérica para capturar qualquer erro inesperado
            return new Response<Product?>(null, 500, "Erro desconhecido.");
        }
    }

    public async Task<Response<List<Product>?>> GetAllProductsAsync(GetAllProductsRequest request)
    {
        try
        {
            var products = await context
                .Products
                .AsNoTracking()
                .Where(x => x.UserId == request.UserId).ToListAsync();

            if (products.Count == 0)
                return new Response<List<Product>?>(null, 404, "Nenhum produto encontrado.");

            return new Response<List<Product>?>(products);
        }
        catch (ArgumentNullException)
        {
            // Exceção para dados nulos
            return new Response<List<Product>?>(null, 400, "Requisição inválida.");
        }
        catch (DbUpdateException)
        {
            // Erro ao tentar salvar no banco de dados
            return new Response<List<Product>?>(null, 500, "Erro ao salvar no banco de dados.");
        }
        catch (InvalidOperationException)
        {
            // Operação inválida
            return new Response<List<Product>?>(null, 500, "Erro interno no servidor.");
        }
        catch (SqlException)
        {
            // Erro específico de SQL (se usar SQL Server)
            return new Response<List<Product>?>(null, 500, "Erro no banco de dados.");
        }
        catch (Exception)
        {
            // Exceção genérica para capturar qualquer erro inesperado
            return new Response<List<Product>?>(null, 500, "Erro desconhecido.");
        }
    }
}