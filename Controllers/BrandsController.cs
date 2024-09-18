using api.Data;
using api.Dtos.Brand;
using api.Dtos.Producer;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.JsonPatch;
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
        public IActionResult Create([FromBody] CreateBrandRequest requestBrand)
        {
            var existingProducer = _context.Producers.FirstOrDefault(p => p.Name == requestBrand.Producer.Name);

            if (existingProducer == null)
            {
                existingProducer = new Producer
                {
                    Name = requestBrand.Producer.Name
                };

                _context.Producers.Add(existingProducer);
            }

            Brand brand = requestBrand.ToBrandFromCreateDto(existingProducer);

            _context.Brands.Add(brand);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = brand.Id }, brand.ToBrandDto());
        }

        [HttpPatch("{id}")]
        public IActionResult UpdatePartial([FromRoute] int id, [FromBody] JsonPatchDocument<CreateBrandRequest> requestBrand)
        {
            if (requestBrand == null)
            {
                return BadRequest();
            }

            if (id <= 0)
            {
                return BadRequest();
            }

            var exisitingBrand = _context.Brands.Include(b => b.Producer).FirstOrDefault(b => b.Id == id);

            if (exisitingBrand == null || exisitingBrand.Producer == null)
            {
                return NotFound();
            }

            CreateProducerRequest producerDto = exisitingBrand.Producer.ToCreateDtoFromProducer();
            CreateBrandRequest brandDto = exisitingBrand.ToCreateDtoFromBrand(producerDto);

            requestBrand!.ApplyTo(brandDto, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            exisitingBrand.Name = brandDto.Name;
            exisitingBrand.Producer.Name = brandDto.Producer.Name;

            _context.SaveChanges();

            return Ok(exisitingBrand.ToBrandDto());
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var brand = _context.Brands.FirstOrDefault(b => b.Id == id);

            if (brand == null)
            {
                return NotFound();
            }

            _context.Brands.Remove(brand);
            _context.SaveChanges();

            return NoContent();
        }
    }
}