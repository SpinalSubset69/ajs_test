using AJSExample.Models;

namespace AJSExample.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> SaveProduct(Product obj);
        Task<List<Product>> ListProducts();
        Task<Product?> GetProductById(int id);
        Task UpdateProductImage(int id, string name);
    }
}