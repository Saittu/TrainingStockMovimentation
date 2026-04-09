using TrainingStockMovimentation.Domain.Entitys;

namespace TrainingStockMovimentation.Domain.Interfaces
{
    public interface ISupplierRepository
    {
        void AddSupplier(Supplier supplier);

        List<Supplier> GetAllSuppliers();

        Supplier GetSupplier(long id);

        void DeleteSupplier(long id);

        void UpdateSupplier(long id, Supplier supplier);

        bool ValidaVinculoProduto(long id);
    }
}
