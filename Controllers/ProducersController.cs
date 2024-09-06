using api.Data;
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
    }
}

