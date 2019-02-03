using System.ComponentModel.DataAnnotations;

namespace ValorProfsApi.Dtos
{
    public class ProductToCreateDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public bool Available { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
