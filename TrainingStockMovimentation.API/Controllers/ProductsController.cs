using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TrainingStockMovimentation.Application.DTO.Products;
using TrainingStockMovimentation.Application.Interfaces;

namespace TrainingStockMovimentation.API.Controllers
{
    public class ProductsController : DefaultController
    {
        private readonly IProductService _service;

        public ProductsController(IProductService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public ActionResult GetProduct(long id)
        {
            var response = _service.GetProducts(id);

            return Ok(response);
        }

        [HttpPost("create-post/{supplierId}")]
        public ActionResult<ProductsDto> CreateProduct([FromRoute]long supplierId, [FromBody]ProductsDto products)
        {
            _service.CreateProdcuts(supplierId, products);

            return Created();
        }

        [HttpPatch("{id}")]
        public ActionResult<ProductsDto> UpdateProduct([FromRoute]long id, [FromBody]ProductsDto products)
        {
            _service.UpdateProducts(id, products);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteProduct(long id)
        {
            _service.DeleteProduct(id);

            return NoContent();
        }
    }
}
