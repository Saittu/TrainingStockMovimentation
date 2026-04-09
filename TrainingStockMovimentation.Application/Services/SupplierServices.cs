using TrainingStockMovimentation.Application.Interfaces;
using TrainingStockMovimentation.Domain.Entitys;
using TrainingStockMovimentation.Domain.Interfaces;
using System.Linq;
using TrainingStockMovimentation.Application.DTO.Suppliers;
using TrainingStockMovimentation.Application.DTO.Products;
using TrainingStockMovimentation.Application.Validators;
using FluentValidation;

namespace TrainingStockMovimentation.Application.Services
{
    public class SupplierServices : ISupplierService
    {
        private readonly ISupplierRepository _repository;
        private readonly IValidator<CreateOrUpdateSupplierDto> _validator;
        private readonly IValidator<SupplierDto> _validatorVinculo;

        public SupplierServices(ISupplierRepository repository, IValidator<CreateOrUpdateSupplierDto> validator, IValidator<SupplierDto> validatorVinculo)
        {
            _repository = repository;
            _validator = validator;
            _validatorVinculo = validatorVinculo;
        }

        public void CreateSupplier(CreateOrUpdateSupplierDto supplier)
        {
            _validator.Validate(supplier);

            var entity = new Supplier
            {
                Name = supplier.Name,
                CNPJ = supplier.CNPJ,
                ProductCategory = supplier.Category
            };

            _repository.AddSupplier(entity);
        }

        public void DeleteSupplier(long id)
        {
            var obj = new SupplierDto { Id = id };

            _validatorVinculo.Validate(obj);

            _repository.DeleteSupplier(id);
        }

        public List<SupplierDto> GetAllSuppliers()
        {
            var response = _repository.GetAllSuppliers();

            return response.Select(x => new SupplierDto
            {
                Id = x.Id,
                Name = x.Name,
                CNPJ = x.CNPJ,
                ProductCategory = x.ProductCategory
            }).ToList();
        }

        public SupplierDto GetSupplier(long id)
        {
            var response = _repository.GetSupplier(id);

            return new SupplierDto
            {
                Id = response.Id,
                Name = response.Name,
                CNPJ = response.CNPJ,
                ProductCategory = response.ProductCategory,
                Products = response.Products != null
                    ? response.Products.Select(p => new ProductsDto
                    {
                        Id = p.Id,
                        Name = p.Name,
                        Description = p.Description,
                        Price = p.Price,
                        Amount = p.Amount,
                        Type = p.Type
                    }).ToList()
                    : new List<ProductsDto>()
            };
        }

        public void UpdateSupplier(long id, CreateOrUpdateSupplierDto supplier)
        {
            _validator.Validate(supplier);

            var response = new Supplier(name: supplier.Name);

            _repository.UpdateSupplier(id, response);
        }
    }
}
