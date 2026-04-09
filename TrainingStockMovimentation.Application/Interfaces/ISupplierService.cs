using TrainingStockMovimentation.Application.DTO.Suppliers;
using TrainingStockMovimentation.Domain.Entitys;

namespace TrainingStockMovimentation.Application.Interfaces
{
    public interface ISupplierService
    {
        void CreateSupplier(CreateOrUpdateSupplierDto supplier);

        List<SupplierDto> GetAllSuppliers();

        SupplierDto GetSupplier(long id);

        void DeleteSupplier(long id);

        void UpdateSupplier(long id, CreateOrUpdateSupplierDto supplier);
    }
}
