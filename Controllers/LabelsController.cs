using api.Data;
using api.Dtos.Label;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/labels")]
    [ApiController]
    public class LabelsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ILabelRepository _labelRepo;
        public LabelsController(ApplicationDbContext context, ILabelRepository labelRepo)
        {
            _context = context;
            _labelRepo = labelRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var labels = await _labelRepo.GetAllDtoAsync();

            return Ok(labels);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var label = await _labelRepo.GetByIdAsync(id);

            if (label == null)
            {
                return NotFound();
            }

            LabelDto labelDto = label.ToLabelDto();

            return Ok(labelDto);
        }
    }
}

