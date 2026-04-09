using TrainingStockMovimentation.Application.DTO.Products;

namespace TrainingStockMovimentation.Application.Interfaces
{
    public interface IProductService
    {
        ProductsDto GetProducts(long id);

        void CreateProdcuts(long supplierId, ProductsDto products);

        void UpdateProducts(long id, ProductsDto products);

        void DeleteProduct(long id);
    }
}
