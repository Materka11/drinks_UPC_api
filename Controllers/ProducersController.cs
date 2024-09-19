using api.Data;
using api.Dtos.Producer;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace api.Controllers
{
    [Route("api/producers")]
    [ApiController]
    public class ProducersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public ProducersController(ApplicationDbContext context)
        {

            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var producers = await _context.Producers.Select(p => p.ToProducerDto()).ToListAsync();

            return Ok(producers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var producer = await _context.Producers.FirstOrDefaultAsync(p => p.Id == id);

            if (producer == null)
            {
                return NotFound();
            }

            ProducerDto producerDto = producer.ToProducerDto();

            return Ok(producerDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProducerRequest requestProducer)
        {
            Producer producer = requestProducer.ToProducerFromCreateDto();
            await _context.Producers.AddAsync(producer);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = producer.Id }, producer.ToProducerDto());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateProducerRequest requestProducer)
        {
            var producer = await _context.Producers.FirstOrDefaultAsync(p => p.Id == id);

            if (producer == null)
            {
                return NotFound();
            }

            _context.Entry(producer).CurrentValues.SetValues(requestProducer);
            await _context.SaveChangesAsync();

            return Ok(producer.ToProducerDto());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var producer = await _context.Producers.FirstOrDefaultAsync(p => p.Id == id);

            if (producer == null)
            {
                return NotFound();
            };

            _context.Producers.Remove(producer);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

