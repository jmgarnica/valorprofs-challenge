namespace ValorProfsApi.Dtos
{
    public class ProductToCreateDto
    {
        public string Name { get; set; }
        public bool Available { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
    }
}
