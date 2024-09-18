using api.Data;
using api.Dtos.Barcode;
using api.Dtos.Brand;
using api.Dtos.Drink;
using api.Dtos.NutritionalValues;
using api.Dtos.Producer;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.JsonPatch;
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

        [HttpPatch("{id}")]
        public IActionResult UpdatePartial([FromRoute] int id, [FromBody] JsonPatchDocument<CreateDrinkRequest> requestDrink)
        {
            if (requestDrink == null)
            {
                return BadRequest();
            }

            if (id <= 0)
            {
                return BadRequest();
            }

            var exisitingDrink = _context.Drinks
                                .Include(d => d.Brand)
                                .ThenInclude(b => b.Producer)
                                .Include(d => d.Category)
                                .Include(d => d.Label)
                                .Include(d => d.Barcode)
                                .Include(d => d.NutritionalValues)
                                .FirstOrDefault(d => d.Id == id);

            if (exisitingDrink == null)
            {
                return NotFound();
            }

            var exisitingBrand = _context.Brands.Include(b => b.Producer).FirstOrDefault(b => b.Id == exisitingDrink.BrandId);

            if (exisitingBrand == null || exisitingBrand.Producer == null)
            {
                return NotFound();
            }

            var exisitingBarcode = _context.Barcodes.FirstOrDefault(b => b.Id == exisitingDrink.Barcode.Id);

            if (exisitingBarcode == null)
            {
                return NotFound();
            }

            var exisitingNutritionalValues = _context.AllNutritionalValues.FirstOrDefault(n => n.Id == exisitingDrink.NutritionalValues!.Id);

            CreateProducerRequest producerDto = exisitingBrand.Producer.ToCreateDtoFromProducer();
            CreateBrandRequest brandDto = exisitingBrand.ToCreateDtoFromBrand(producerDto);
            CreateBarcodeRequest barcodeDto = exisitingBarcode.ToCreateDtoFromBarcode();
            CreateNutritionalValuesRequest? nutritionalValuesDto = exisitingNutritionalValues.ToCreateDtoFromNutritionalValues();

            CreateDrinkRequest drinkDto = exisitingDrink.ToCreateDtoFromDrink(brandDto, barcodeDto, nutritionalValuesDto);

            requestDrink.ApplyTo(drinkDto, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            exisitingDrink.Name = drinkDto.Name;
            exisitingDrink.Brand.Name = drinkDto.Brand.Name;
            exisitingDrink.Brand.Producer!.Name = drinkDto.Brand.Producer.Name;
            exisitingDrink.Description = drinkDto.Description;
            exisitingDrink.Capacity = drinkDto.Capacity;
            exisitingDrink.CategoryId = drinkDto.CategoryId;
            exisitingDrink.Storage = drinkDto.Storage;
            exisitingDrink.Barcode.EAN = drinkDto.Barcode.EAN;
            exisitingDrink.Barcode.JAN = drinkDto.Barcode.JAN;
            exisitingDrink.Barcode.ITF_14 = drinkDto.Barcode.ITF_14;
            exisitingDrink.Barcode.ISBN = drinkDto.Barcode.ISBN;
            exisitingDrink.Barcode.UPC = drinkDto.Barcode.UPC;
            exisitingDrink.Composition = drinkDto.Composition;
            exisitingDrink.LabelId = drinkDto.LabelId;
            exisitingDrink.NutritionalValues!.Calories = drinkDto.NutritionalValues!.Calories;
            exisitingDrink.NutritionalValues.EnergyValue = drinkDto.NutritionalValues.EnergyValue;
            exisitingDrink.NutritionalValues.Fat = drinkDto.NutritionalValues.Fat;
            exisitingDrink.NutritionalValues.SaturatedFat = drinkDto.NutritionalValues.SaturatedFat;
            exisitingDrink.NutritionalValues.Carbohydrates = drinkDto.NutritionalValues.Carbohydrates;
            exisitingDrink.NutritionalValues.Sugar = drinkDto.NutritionalValues.Sugar;
            exisitingDrink.NutritionalValues.Protein = drinkDto.NutritionalValues.Protein;
            exisitingDrink.NutritionalValues.Salt = drinkDto.NutritionalValues.Salt;
            exisitingDrink.NutritionalValues.Fiber = drinkDto.NutritionalValues.Fiber;
            exisitingDrink.NutritionalValues.Niacin = drinkDto.NutritionalValues.Niacin;
            exisitingDrink.NutritionalValues.Biotin = drinkDto.NutritionalValues.Biotin;
            exisitingDrink.NutritionalValues.Zinc = drinkDto.NutritionalValues.Zinc;
            exisitingDrink.NutritionalValues.Selenium = drinkDto.NutritionalValues.Selenium;
            exisitingDrink.NutritionalValues.VitaminC6 = drinkDto.NutritionalValues.VitaminC6;
            exisitingDrink.NutritionalValues.VitaminC = drinkDto.NutritionalValues.VitaminC;
            exisitingDrink.NutritionalValues.VitaminB5 = drinkDto.NutritionalValues.VitaminB5;
            exisitingDrink.NutritionalValues.VitaminB6 = drinkDto.NutritionalValues.VitaminB6;
            exisitingDrink.NutritionalValues.VitaminB12 = drinkDto.NutritionalValues.VitaminB12;
            exisitingDrink.NutritionalValues.VitaminE = drinkDto.NutritionalValues.VitaminE;
            exisitingDrink.Preparation = drinkDto.Preparation;

            _context.SaveChanges();

            return Ok(exisitingDrink.ToDrinkDto());
        }

    }
}
