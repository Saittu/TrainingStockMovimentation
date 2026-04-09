using TrainingStockMovimentation.Domain.Enums;

namespace TrainingStockMovimentation.Domain.Entitys
{
    public class StockMovement
    {
        public StockMovement() { }

        public long Id { get; set; }

        public long ProductId { get; set; }

        public MovimentType Type { get; set; }

        public DateTime Date { get; set; }

        public Products Product { get; set; }
    }
}
