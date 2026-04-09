using FluentValidation;
using TrainingStockMovimentation.Application.DTO.Suppliers;
using TrainingStockMovimentation.Domain.Interfaces;

namespace TrainingStockMovimentation.Application.Validators.Supplier
{
    public class SupplierValidator : AbstractValidator<SupplierDto>
    {
        private readonly ISupplierRepository _repository;

        public SupplierValidator(ISupplierRepository repository)
        {
            _repository = repository;

            RuleFor(x => x.Id)
                .Must(ValidaVinculoProduto)
                .WithMessage("Não é possivel excluir o fornecedor pois o mesmo possui produtos cadastrados.");
        }

        private bool ValidaVinculoProduto(long id)
        {
            var response = _repository.ValidaVinculoProduto(id);

            if (!response)
                return false;

            return true;
        }
    }
}
