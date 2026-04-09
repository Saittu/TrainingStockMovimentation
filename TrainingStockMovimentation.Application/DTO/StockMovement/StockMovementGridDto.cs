using TrainingStockMovimentation.Domain.Enums;

namespace TrainingStockMovimentation.Application.DTO.StockMovement
{
    public class StockMovementGridDto
    {
        public MovimentType MovimentType { get; set; }

        public DateTime Created_At { get; set; }
    }
}
