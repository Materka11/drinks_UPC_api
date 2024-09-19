using api.Data;
using api.Dtos.Label;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public async Task<IActionResult> GetAll()
        {
            var labels = await _context.Labels.Select(l => l.ToLabelDto()).ToListAsync();

            return Ok(labels);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var label = await _context.Labels.FirstOrDefaultAsync(l => l.Id == id);

            if (label == null)
            {
                return NotFound();
            }

            LabelDto labelDto = label.ToLabelDto();

            return Ok(labelDto);
        }
    }
}

