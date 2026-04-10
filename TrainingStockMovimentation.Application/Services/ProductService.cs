using FluentValidation;
using TrainingStockMovimentation.Application.DTO.Products;
using TrainingStockMovimentation.Application.Interfaces;
using TrainingStockMovimentation.Domain.Entitys;
using TrainingStockMovimentation.Domain.Interfaces;

namespace TrainingStockMovimentation.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        private readonly IValidator<ProductsDto> _validator;
        //private readonly IValidator<long> _validatorVinculos;

        public ProductService(IProductRepository repository, IValidator<ProductsDto> validator)
        {
            _repository = repository;
            _validator = validator;
            //_validatorVinculos = validatorVinculos;
        }

        public void CreateProdcuts(long supplierId, ProductsDto products)
        {
            _validator.Validate(products);

            var entity = new Products
            {
                Id = 0,
                Name = products.Name.Trim(),
                Description = products.Description,
                Price = products.Price,
                Amount = products.Amount,
                Type = products.Type,
                SupplierId = supplierId
            };

            _repository.CreateProduct(entity);
        }

        public void DeleteProduct(long id)
        {
            //_validatorVinculos.Validate(id);

            _repository.DeleteProduct(id);
        }

        public ProductsDto GetProducts(long id)
        {
            var response = _repository.GetProducts(id);

            return new ProductsDto
            {
                Id = response.Id,
                Name = response.Name,
                Description = response.Description,
                Price = response.Price,
                Amount = response.Amount,
                Type = response.Type,
                SupplierId = response.SupplierId
            };
        }

        public void UpdateProducts(long id, ProductsDto products)
        {
            _validator.Validate(products);

            var entity = new Products
            {
                Name = products.Name,
                Description = products.Description,
                Price = products.Price,
                Amount = products.Amount,
                Type = products.Type,
            };

            _repository.UpdateProduct(id, entity);
        }
    }
}
