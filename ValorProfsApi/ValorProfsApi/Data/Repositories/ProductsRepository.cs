using System;
using System.Collections.Generic;
using ValorProfsApi.Data.Entities;

namespace ValorProfsApi.Data.Repositories
{
    public class ProductsRepository : IProductsRepository
    {
        public void Delete(long id)
        {
            //TODO:
        }

        public long Insert(Product product)
        {
            //TODO:
            return 1;
        }

        public List<Product> Select()
        {
            //TODO:
            return new List<Product>() { new Product()
            {
                Available = true,
                DateCreated = DateTime.UtcNow,
                Description = "Descripton",
                Id =1,
                Name = "Name",
                Price= 5.50
            }};
        }

        public Product Select(long id)
        {
            //TODO:
            //return null;
            return new Product()
            {
                Available = true,
                DateCreated = DateTime.UtcNow,
                Description = "Descripton",
                Id = id,
                Name = "Name",
                Price = 5.50
            };
        }

        public void Update(long id, Product product)
        {
            //TODO:
        }
    }
}