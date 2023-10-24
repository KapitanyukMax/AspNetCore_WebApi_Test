using BusinessLogic.ApiModels.Products;
using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore_WebAPI_GrandGames.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService _productsService;

        public ProductsController(IProductsService productsService)
        {
            _productsService = productsService;
        }

        [HttpGet("/all-products")]
        public IActionResult Get()
        {
            return Ok(_productsService.Get());
        }

        [HttpGet]
        public IActionResult GetByIdFromQuery([FromQuery] int modelId)
        {
            return Ok(_productsService.Get(modelId));
        }

        [HttpGet("{modelId}")]
        public IActionResult GetByIdFromRoute([FromRoute] int modelId)
        {
            return Ok(_productsService.Get(modelId));
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateProductModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _productsService.Create(model);

            return Ok();
        }

        [HttpPut]
        public IActionResult Edit([FromBody] EditProductModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _productsService.Edit(model);

            return Ok();
        }

        [HttpDelete("{modelId}")]
        public IActionResult Delete([FromRoute] int modelId)
        {
            _productsService.Delete(modelId);

            return Ok();
        }
    }
}
