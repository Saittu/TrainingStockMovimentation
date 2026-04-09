using TrainingStockMovimentation.Domain.Enums;

namespace TrainingStockMovimentation.Domain.Entitys
{
    public class Products
    {
        public Products() { }

        public long Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; } = string.Empty;

        public CategoryProduct Type { get; set; }

        public decimal Price { get; set; }

        public int Amount { get; set; }

        public long SupplierId { get; set; }

        public Supplier Supplier { get; set; }

        public List<StockMovement> stockMovements { get; set; }
    }
}
