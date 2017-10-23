using System.Linq;
using Assignment4;
using Microsoft.AspNetCore.Mvc;

namespace WebService.Controllers
{
    [Route("/api/categories")]
    public class CategoriesController : Controller
    {
        private DataService _dataService;

        public CategoriesController(DataService dataService)
        {
            _dataService = dataService;
        }

        [HttpGet]
        public IActionResult GetCategories()
        {
            return Ok( _dataService.GetCategories() );
        }

        [HttpGet("{id}")]
        public IActionResult GetCategory(int id)
        {
            var category = _dataService.GetCategories()
                .FirstOrDefault(x => x.Id == id);

            if (category == null) return NotFound();

            return Ok( category );
        }
    }
}