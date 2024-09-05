using api.Data;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace api.Controllers
{
    [Route("api/drinks")]
    [ApiController]
    public class DrinksController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DrinksController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var drinks = _context.Drinks
                        .Include(d => d.Brand)
                        .ThenInclude(b => b.Producer)
                        .Include(d => d.Category)
                        .Include(d => d.Label)
                        .Include(d => d.Barcode)
                        .Include(d => d.NutritionalValues)
                        .Select(d => d.ToDrinkDto())
                        .ToList();


            return Ok(drinks);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var drink = _context.Drinks
                        .Include(d => d.Brand)
                        .ThenInclude(b => b.Producer)
                        .Include(d => d.Category)
                        .Include(d => d.Label)
                        .Include(d => d.Barcode)
                        .FirstOrDefault(d => d.Id == id);

            if (drink == null)
            {
                return NotFound();
            }

            var drinkDto = drink.ToDrinkDto();

            return Ok(drinkDto);
        }
    }
}
