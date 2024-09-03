using System;
using Microsoft.AspNetCore.Mvc;
using api.Data;
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
                        .Include(d => d.Category)
                        .Include(d => d.Label)
                        .Include(d => d.Barcode)
                        .Select(d => new
                        {
                            d.Id,
                            d.Name,
                            BrandName = d.Brand.Name,
                            CategoryName = d.Category.Name,
                            LabelName = d.Label.Name,
                            d.Description,
                            d.Capacity,
                            d.Storage,
                            d.Composition,
                            d.Preparation
                        })
                        .ToList();


            return Ok(drinks);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id) 
        {
            var drink = _context.Drinks
                        .Include(d => d.Brand)
                        .Include(d => d.Category)
                        .Include(d => d.Label)
                        .Include(d => d.Barcode)
                        .Select(d => new
                        {
                            d.Id,
                            d.Name,
                            BrandName = d.Brand.Name,
                            CategoryName = d.Category.Name,
                            LabelName = d.Label.Name,
                            d.Description,
                            d.Capacity,
                            d.Storage,
                            d.Composition,
                            d.Preparation
                        })
                        .FirstOrDefault(d => d.Id == id);

            if (drink == null)
            {
                return NotFound();
            }

            return Ok(drink);
        }
    }
}
