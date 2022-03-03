using AJSExample.Models;
using Microsoft.EntityFrameworkCore;

namespace AJSExample.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Product> Product { get; set; }
    }
}