using api.Data;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/brands")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BrandsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var brands = _context.Brands
                        .Include(b => b.Producer)
                        .Select(b => b.ToBrandDto())
                        .ToList();

            return Ok(brands);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var brand = _context.Brands
                        .Include(b => b.Producer)
                        .FirstOrDefault(b => b.Id == id);

            if (brand == null)
            {
                return NotFound();
            }

            var brandDto = brand.ToBrandDto();

            return Ok(brandDto);
        }
    }
}

