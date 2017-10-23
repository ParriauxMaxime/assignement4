using Assignment4.PartII;
using Microsoft.AspNetCore.Mvc;

namespace WebService.Controllers
{
    [Route("/api/products")]
    public class ProductsController : Controller
    {
        private DataService _dataService;

        public ProductsController(DataService dataService)
        {
            _dataService = dataService;
        }

        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            var product = _dataService.GetProduct(id);

            if (product == null) return NotFound();

            return Ok( product );
        }

        [HttpGet("category/{id}")]
        public IActionResult GetProductsByCategoryId(int id)
        {
            var result = _dataService.GetProductsByCategoryId(id);

            if (result.Count == 0) return NotFound(result);

            return Ok( result );
        }

        [HttpGet("name/{query}")]
        public IActionResult GetProductsBySubstring(string query)
        {
            var result = _dataService.GetProductsBySubstring(query);

            if (result.Count == 0) return NotFound(result);

            return Ok( result );
        }
    }
}