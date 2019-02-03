using Microsoft.EntityFrameworkCore;
using ValorProfsApi.Data.Entities;

namespace ValorProfsApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options){ }

        public DbSet<Product> Products { get; set; }

        public DbSet<User> Users { get; set; }
    }
}