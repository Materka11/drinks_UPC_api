using api.Data;
using api.Dtos.Producer;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Mvc;


namespace api.Controllers
{
    [Route("api/producers")]
    [ApiController]
    public class ProducersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IProducerRepository _producerRepo;
        public ProducersController(ApplicationDbContext context, IProducerRepository producerRepo)
        {
            _context = context;
            _producerRepo = producerRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var producers = await _producerRepo.GetAllDtoAsync();

            return Ok(producers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var producer = await _producerRepo.GetByIdAsync(id);

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
            await _producerRepo.CreateAsync(producer);

            return CreatedAtAction(nameof(GetById), new { id = producer.Id }, producer.ToProducerDto());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateProducerRequest requestProducer)
        {
            var producer = await _producerRepo.UpdateAsync(id, requestProducer);

            if (producer == null)
            {
                return NotFound();
            }

            return Ok(producer.ToProducerDto());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var producer = await _producerRepo.DeleteAsync(id);

            if (producer == null)
            {
                return NotFound();
            };

            return NoContent();
        }
    }
}

