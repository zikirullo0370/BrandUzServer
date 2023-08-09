using BrandUzServer.Entity;

namespace BrandUzServer.Dtos
{
    public class GetClothDto
    {
        public GetClothDto(Cloth entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            Brand = entity.Brand;
            Price = entity.Price;
            Size = entity.Size;
            Made = entity.Made;
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public double Price { get; set; }
        public string Size { get; set; }
        public string Made { get; set; }
    }
}
