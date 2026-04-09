using TrainingStockMovimentation.Application.DTO.StockMovement;

namespace TrainingStockMovimentation.Application.Interfaces
{
    public interface IStockMovementService
    {
        List<StockMovementGridDto> GetStockMovementGrids();

        void CreateStockMovemnt(long prodcutId, CreateStockMovementDto dto);

        void UpdateStockMovemnt(long id, CreateStockMovementDto dto);

        void DeleteStockMovement(long id);

    }
}
