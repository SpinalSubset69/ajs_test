using AJSExample.Interfaces;
using AJSExample.Models;
using Microsoft.EntityFrameworkCore;

namespace AJSExample.Data.Implementation
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Product?> GetProductById(int id)
        {
            return await _context.Product.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Product>> ListProducts()
        {
            return await _context.Product.ToListAsync();
        }

        public async Task<Product> SaveProduct(Product obj)
        {
            _context.Product.Add(obj);
            await _context.SaveChangesAsync();
            return obj;
        }

        public async Task UpdateProductImage(int id, string name)
        {
            var prod = await _context.Product.Where(x => x.Id == id).FirstOrDefaultAsync();
            prod.Image = name;
            _context.Product.Update(prod);
            await _context.SaveChangesAsync();
        }
    }
}