using TrainingStockMovimentation.Application.DTO.Products;
using TrainingStockMovimentation.Domain.Entitys;
using TrainingStockMovimentation.Domain.Enums;

namespace TrainingStockMovimentation.Application.DTO.Suppliers
{
    public class SupplierDto
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string CNPJ {  get; set; }

        public CategoryProduct ProductCategory { get; set; }

        public List<ProductsDto>? Products { get; set; }
    }
}
