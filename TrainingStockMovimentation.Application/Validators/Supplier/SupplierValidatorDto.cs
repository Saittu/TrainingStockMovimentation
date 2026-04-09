using FluentValidation;
using TrainingStockMovimentation.Application.DTO.Suppliers;

namespace TrainingStockMovimentation.Application.Validators.Supplier
{
    public class SupplierValidatorDto : AbstractValidator<CreateOrUpdateSupplierDto>
    {
        public SupplierValidatorDto()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("O nome não pode estar vazio.");

            RuleFor(x => x.Name)
                .MaximumLength(100)
                .WithMessage("O nome ultrapassa o limite de caracteres.");

            RuleFor(x => x.CNPJ)
                .NotEmpty()
                .WithMessage("O CNPJ deve ser preenchido.");

            RuleFor(x => x.Category)
                .NotEmpty()
                .WithMessage("Selecione uma categoria de venda.");
        }
    }
}
