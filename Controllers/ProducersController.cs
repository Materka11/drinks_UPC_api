using api.Data;
using api.Dtos.Producer;
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

            ProducerDto producerDto = producer.ToProducerDto();

            return Ok(producerDto);
        }
        [HttpPost]
        public IActionResult Create([FromBody] CreateProducerRequest requestProducer)
        {
            Producer producer = requestProducer.ToProducerFromCreateDto();
            _context.Producers.Add(producer);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = producer.Id }, producer.ToProducerDto());
        }
        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] UpdateProducerRequest requestProducer)
        {
            var producer = _context.Producers.FirstOrDefault(p => p.Id == id);

            if (producer == null)
            {
                return NotFound();
            }

            _context.Entry(producer).CurrentValues.SetValues(requestProducer);
            _context.SaveChanges();

            return Ok(producer.ToProducerDto());
        }
    }
}

