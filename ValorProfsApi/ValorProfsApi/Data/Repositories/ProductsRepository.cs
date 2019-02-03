using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using ValorProfsApi.Data.Entities;

namespace ValorProfsApi.Data.Repositories
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly DataContext _context;

        public ProductsRepository(DataContext context)
        {
            this._context = context;
        }

        public async Task<long> DeleteAsync(Product product)
        {
            var result = this._context.Remove<Product>(product);
            await _context.SaveChangesAsync();
            return result.Entity.Id;
        }

        public async Task<long> InsertAsync(Product product)
        {
            var result = this._context.Add<Product>(product);
            await _context.SaveChangesAsync();
            return result.Entity.Id;        
        }

        public async Task<IEnumerable<Product>> SelectAsync()
        {
            var products = await this._context.Products.ToListAsync();
            return products;
        }

        public async Task<Product> SelectAsync(long id)
        {
            var product = await this._context.Products.FirstOrDefaultAsync(p => p.Id == id);
            return product;
        }

        public async Task<long> UpdateAsync(long id, Product product)
        {
            var result = this._context.Update<Product>(product);
            await _context.SaveChangesAsync();
            return result.Entity.Id;
        }
    }
}