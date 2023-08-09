using BrandUzServer.Data;
using BrandUzServer.Dtos;
using BrandUzServer.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;

namespace BrandUzServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClothController : ControllerBase
    {
        private readonly AppDbContext dbContext;

        public ClothController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateClothDto dto)
        {
            var created = dbContext.Cloths.Add(new Cloth
            {
                Id = Guid.NewGuid(),
                Name = dto.Name,
                Brand = dto.Brand,
                Price = dto.Price,
                Size = dto.Size,
                Made = dto.Made,
            });

            await dbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCloth), new { id = created.Entity.Id }, new GetClothDto(created.Entity));
        }
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string search)
        {
            var clothQuery = dbContext.Cloths.AsQueryable();

            if (false == string.IsNullOrWhiteSpace(search))
                clothQuery = clothQuery.Where(c =>
                    c.Brand.ToLower().Contains(search.ToLower()));

            var cloth = await clothQuery.ToListAsync();
            return Ok(cloth);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCloth([FromRoute] Guid id)
        {
            var getCloth = await dbContext.Cloths
                .FirstOrDefaultAsync(c => c.Id == id);

            if (getCloth == null)
                return NotFound();

            return Ok(new GetClothDto(getCloth));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, UpdateClothDto dto)
        {
            var updateCloth = await dbContext.Cloths.
                FirstOrDefaultAsync(c => c.Id == id);
            if (updateCloth == null)
                return NotFound();

            updateCloth.Name = dto.Name;
            updateCloth.Brand = dto.Brand;
            updateCloth.Price = dto.Price;
            updateCloth.Size = dto.Size;
            updateCloth.Made = dto.Made;

            await dbContext.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleted([FromRoute] Guid id)
        {
            var deleteQuery = await dbContext.Cloths
                .FirstOrDefaultAsync (c => c.Id == id);

            if(deleteQuery == null)
                return NotFound();

            dbContext.Cloths.Remove(deleteQuery);
            await dbContext.SaveChangesAsync();
            return Ok();

        }
            
    }   
}
