using TrainingStockMovimentation.Domain.Entitys;
using TrainingStockMovimentation.Domain.Enums;

namespace TrainingStockMovimentation.Application.DTO.Products
{
    public class ProductsDto
    {
        public long Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; } = string.Empty;

        public CategoryProduct Type { get; set; }

        public decimal Price { get; set; }

        public int Amount { get; set; }

        public long SupplierId { get; set; }

    }
}
