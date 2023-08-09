using System.ComponentModel.DataAnnotations;

namespace BrandUzServer.Entity
{
    public class Shoes
    {
        [Key]
        public Guid Id { get; set; }
        [Required, MaxLength(50)]
        public string Brand { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public string Size { get; set; }
        [Required, MaxLength(50), MinLength(2)]
        public string Made { get; set; }
    }
}
