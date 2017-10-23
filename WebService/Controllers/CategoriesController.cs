using System.Linq;
using Assignment4.PartII;
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
        
        [HttpPost]
        public IActionResult PostCategory([FromBody] Category category)
        {
            var cat = _dataService.CreateCategory(category.Name, category.Description);

            return Created("", cat); // FIXME: what is uri in this case?
        }

        [HttpPut("{id}")]
        public IActionResult PutCategory(int id, [FromBody] Category category)
        {
            bool found = _dataService.UpdateCategory(id, category.Name, category.Description);

            if (!found) return NotFound();

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            bool found = _dataService.DeleteCategory(id);

            if (!found) return NotFound();

            return Ok();
        }
    }
}