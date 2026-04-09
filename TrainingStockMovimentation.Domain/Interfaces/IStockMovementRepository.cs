using TrainingStockMovimentation.Domain.Entitys;

namespace TrainingStockMovimentation.Domain.Interfaces
{
    public interface IStockMovementRepository
    {
        List<StockMovement> GetStockMovementList();

        void CreateStockMovement(StockMovement entity);

        void UpdateStockMovement(long id, StockMovement entity);

        void DeleteStockMovement(long id);

    }
}
