using TrainingStockMovimentation.Domain.Enums;

namespace TrainingStockMovimentation.Application.DTO.Suppliers
{
    public class CreateOrUpdateSupplierDto
    {
        public string? Name { get; set; }

        public string? CNPJ { get; set; }

        public CategoryProduct Category { get; set; }
    }
}
