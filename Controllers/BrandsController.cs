using api.Data;
using api.Dtos.Brand;
using api.Dtos.Producer;
using api.Interfaces;
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
        private readonly IBrandRepository _brandRepo;

        public BrandsController(ApplicationDbContext context, IBrandRepository brandRepo)
        {
            _context = context;
            _brandRepo = brandRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var brands = await _brandRepo.GetAllDtoAsync();

            return Ok(brands);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var brand = await _brandRepo.GetByIdAsync(id);

            if (brand == null)
            {
                return NotFound();
            }

            BrandDto brandDto = brand.ToBrandDto();

            return Ok(brandDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateBrandRequest requestBrand)
        {
            var existingProducer = await _context.Producers.FirstOrDefaultAsync(p => p.Name == requestBrand.Producer.Name);

            if (existingProducer == null)
            {
                existingProducer = new Producer
                {
                    Name = requestBrand.Producer.Name
                };

                await _context.Producers.AddAsync(existingProducer);
            }

            Brand brand = requestBrand.ToBrandFromCreateDto(existingProducer);

            await _brandRepo.CreateAsync(brand);

            return CreatedAtAction(nameof(GetById), new { id = brand.Id }, brand.ToBrandDto());
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdatePartial([FromRoute] int id, [FromBody] JsonPatchDocument<CreateBrandRequest> requestBrand)
        {
            if (requestBrand == null)
            {
                return BadRequest();
            }

            if (id <= 0)
            {
                return BadRequest();
            }

            var exisitingBrand = await _brandRepo.GetByIdAsync(id);

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

            await _context.SaveChangesAsync();

            return Ok(exisitingBrand.ToBrandDto());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var brand = await _brandRepo.DeleteAsync(id);

            if (brand == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}