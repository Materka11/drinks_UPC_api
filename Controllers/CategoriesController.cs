using api.Data;
using api.Interfaces;
using api.Queries;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ICategoryRepository _categoryRepo;
        public CategoriesController(ApplicationDbContext context, ICategoryRepository categoryRepo)
        {
            _context = context;
            _categoryRepo = categoryRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] CategoryGetAllQuery query)
        {
            var categories = await _categoryRepo.GetAllDtoAsync(query);

            return Ok(categories);
        }
    };
}


