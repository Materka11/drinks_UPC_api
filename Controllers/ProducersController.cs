using api.Data;
using api.Dtos.Producer;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;


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
        public IActionResult GetAll()
        {
            var producers = _context.Producers.Select(p => p.ToProducerDto()).ToList();

            return Ok(producers);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var producer = _context.Producers.FirstOrDefault(p => p.Id == id);

            if (producer == null)
            {
                return NotFound();
            }

            var producerDto = producer.ToProducerDto();

            return Ok(producerDto);
        }
        [HttpPost]
        public IActionResult Create([FromBody] CreateProducerRequest producerDto)
        {
            var producer = producerDto.ToProducerFromCreateDto();
            _context.Producers.Add(producer);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = producer.Id }, producer.ToProducerDto());
        }
    }
}

