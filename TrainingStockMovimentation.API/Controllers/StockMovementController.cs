using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TrainingStockMovimentation.Application.DTO.StockMovement;
using TrainingStockMovimentation.Application.Interfaces;

namespace TrainingStockMovimentation.API.Controllers
{
    public class StockMovementController : DefaultController
    {
        private readonly IStockMovementService _service;

        public StockMovementController(IStockMovementService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult GetAllStockMovement()
        {
            var response = _service.GetStockMovementGrids();

            return Ok(response);
        }

        [HttpPost("{productId}")]
        public ActionResult<CreateStockMovementDto> CreateStockMovement([FromRoute]long productId, [FromBody]CreateStockMovementDto dto)
        {
            _service.CreateStockMovemnt(productId, dto);

            return Created();
        }

        [HttpPatch("{id}")]
        public ActionResult<CreateStockMovementDto> UpdateStockMovement([FromRoute]long id, [FromBody]CreateStockMovementDto dto)
        {
            _service.UpdateStockMovemnt(id, dto);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteStockMovement(long id) 
        {
            _service.DeleteStockMovement(id);

            return NoContent();
        }
    }
}
