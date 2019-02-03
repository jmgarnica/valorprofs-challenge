namespace ValorProfsApi.Data.Entities
{
    public class ProductToListDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool Available { get; set; }
        public double Price { get; set; }
    }
}
