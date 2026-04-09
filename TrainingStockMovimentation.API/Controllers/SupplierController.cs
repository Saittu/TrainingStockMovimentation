using Microsoft.AspNetCore.Mvc;
using TrainingStockMovimentation.Application.DTO.Suppliers;
using TrainingStockMovimentation.Application.Interfaces;
using TrainingStockMovimentation.Domain.Entitys;

namespace TrainingStockMovimentation.API.Controllers
{
    public class SupplierController : DefaultController
    {
        private readonly ISupplierService _supplierService;

        public SupplierController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        [HttpPost("create-supplier")]
        public ActionResult CreateSupplier([FromBody]CreateOrUpdateSupplierDto supplier)
        {
            _supplierService.CreateSupplier(supplier);

            return Ok();
        }

        [HttpGet]
        public ActionResult GetAllSuppliers()
        {
            var response = _supplierService.GetAllSuppliers();

            return Ok(response);
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult GetSupplier(long id)
        {
            var response = _supplierService.GetSupplier(id);

            return Ok(response);
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult DeleteSupplier(long id)
        {
            _supplierService.DeleteSupplier(id);

            return NoContent();
        }

        [HttpPatch]
        [Route("{id}")]
        public ActionResult UpdateSupplier([FromRoute]long id, [FromBody] CreateOrUpdateSupplierDto supplier)
        {
            _supplierService.UpdateSupplier(id, supplier);

            return NoContent();
        }
    }
}
