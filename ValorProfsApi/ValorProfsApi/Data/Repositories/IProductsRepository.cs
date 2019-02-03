using System.Collections.Generic;
using System.Threading.Tasks;
using ValorProfsApi.Data.Entities;

namespace ValorProfsApi.Data.Repositories
{
    public interface IProductsRepository
    {
        Task<IEnumerable<Product>> SelectAsync();

        Task<Product> SelectAsync(long id);

        Task<long> InsertAsync(Product product);

        Task<long> UpdateAsync(long id, Product product);

        Task<long> DeleteAsync(Product product);
    }
}