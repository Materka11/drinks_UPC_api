using api.Data;
using api.Dtos.Drink;
using api.Mappers;
using api.Models;
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

            DrinkDto drinkDto = drink.ToDrinkDto();

            return Ok(drinkDto);
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateDrinkRequest requestDrink)
        {
            var existingBrand = _context.Brands.Include(b => b.Producer).FirstOrDefault(b => b.Name == requestDrink.Brand.Name);

            if (existingBrand == null)
            {
                var exisitingProducer = _context.Producers.FirstOrDefault(p => p.Name == requestDrink.Brand.Producer.Name);

                if (exisitingProducer == null)
                {
                    exisitingProducer = new Producer
                    {
                        Name = requestDrink.Brand.Producer.Name,
                    };

                    _context.Producers.Add(exisitingProducer);
                }

                existingBrand = new Brand
                {
                    Name = requestDrink.Brand.Name,
                    Producer = exisitingProducer
                };

                _context.Brands.Add(existingBrand);
            }

            var existingCategory = _context.Categories.FirstOrDefault(c => c.Id == requestDrink.CategoryId);

            if (existingCategory == null)
            {
                return NotFound();
            }

            Barcode barcode = requestDrink.Barcode.ToBarcodeFromCreateDto();

            Label? label = null;

            if (requestDrink.LabelId != null)
            {
                label = _context.Labels.FirstOrDefault(l => l.Id == requestDrink.LabelId);

                if (label == null)
                {
                    return NotFound();
                }
            }

            NutritionalValues? nutritionalValues = null;

            if (requestDrink.NutritionalValues != null)
            {
                nutritionalValues = requestDrink.NutritionalValues.ToNutritionalValuesFromCreateDto();
            }

            Drink drink = requestDrink.ToDrinkFromCreateDto(existingBrand, existingCategory, barcode, label, nutritionalValues);

            _context.Drinks.Add(drink);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = drink.Id }, drink.ToDrinkDto());
        }
    }
}
