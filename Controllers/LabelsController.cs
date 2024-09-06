using api.Data;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/labels")]
    [ApiController]
    public class LabelsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public LabelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var labels = _context.Labels.Select(l => l.ToLabelDto()).ToList();

            return Ok(labels);
        }
        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var label = _context.Labels.FirstOrDefault(l => l.Id == id);

            if (label == null)
            {
                return NotFound();
            }

            var labelDto = label.ToLabelDto();

            return Ok(labelDto);
        }
    }
}

