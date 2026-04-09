using TrainingStockMovimentation.Domain.Enums;

namespace TrainingStockMovimentation.Application.DTO.StockMovement
{
    public class CreateStockMovementDto
    {
        public long ProductId { get; set; }

        public MovimentType MovimentType { get; set; }

        public DateTime Created_At { get; set; }
    }
}
