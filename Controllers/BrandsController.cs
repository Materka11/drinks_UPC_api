using api.Data;
using api.Dtos.Brand;
using api.Mappers;
using api.Models;
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

            BrandDto brandDto = brand.ToBrandDto();

            return Ok(brandDto);
        }
        [HttpPost]
        public IActionResult Create([FromBody] CreateBrandRequest brandDto)
        {
            var existingProducer = _context.Producers.FirstOrDefault(p => p.Name == brandDto.Producer.Name);

            if (existingProducer == null)
            {
                existingProducer = new Producer
                {
                    Name = brandDto.Producer.Name
                };

                _context.Producers.Add(existingProducer);
            }

            Brand brand = brandDto.ToBrandFromCreateDto(existingProducer);

            _context.Brands.Add(brand);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = brand.Id }, brand.ToBrandDto());
        }
    }
}

