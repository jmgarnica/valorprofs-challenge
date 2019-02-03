using System;

namespace ValorProfsApi.Data.Entities
{
    public class Product
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool Available { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
