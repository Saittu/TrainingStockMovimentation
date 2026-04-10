using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrainingStockMovimentation.Application.DTO.ContaBC;
using TrainingStockMovimentation.Application.Interfaces;

namespace TrainingStockMovimentation.API.Controllers
{
    public class ContaBCController : DefaultController
    {
        private readonly IContaBCService _service;

        public ContaBCController(IContaBCService service) 
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult GetAllConta([FromQuery]FilterContaBCDto filter)
        {
            var response = _service.GetAllContaBcGrid(filter);

            return Ok(response);
        }

        [HttpPost("create-conta-bancaria")]
        public ActionResult CreateContaBC(ContaBCDto contaBc)
        {
            _service.CreateContaBC(contaBc);

            return Created();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteContaBC(long id)
        {
            _service.DeleteContaBC(id);

            return NoContent();
        }

        [HttpPatch("{id}")]
        public ActionResult UpdateContaBC([FromRoute]long id, [FromBody]ContaBCUpdateDto conta)
        {
            _service.UpdateContaBC(id, conta);

            return NoContent();
        }

        [HttpGet("{id}")]
        public ActionResult GetConta(long id)
        {
            var response = _service.GetContaBC(id);

            return Ok(response);
        }

    }
}
