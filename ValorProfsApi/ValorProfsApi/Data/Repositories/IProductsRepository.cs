using System.Collections.Generic;
using System.Threading.Tasks;
using ValorProfsApi.Data.Entities;

namespace ValorProfsApi.Data.Repositories
{
    public interface IProductsRepository
    {
        List<Product> Select();
        Product Select(long id);
        long Insert(Product product);
        void Update(long id, Product product);
        void Delete(long id);
    }
}