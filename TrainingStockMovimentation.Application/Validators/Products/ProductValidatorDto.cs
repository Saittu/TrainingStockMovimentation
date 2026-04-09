using FluentValidation;
using System.Runtime.CompilerServices;
using TrainingStockMovimentation.Application.DTO.Products;
using TrainingStockMovimentation.Domain.Interfaces;

namespace TrainingStockMovimentation.Application.Validators.NewFolder
{
    public class ProductValidatorDto : AbstractValidator<ProductsDto>
    {
        private readonly IProductRepository _repository;

        public ProductValidatorDto(IProductRepository repository)
        {
            _repository = repository;
        }

        public ProductValidatorDto() 
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("O nome do produto não pode ser vazio.");

            RuleFor(x => x.Description)
                .NotEmpty()
                .WithMessage("A descrição não pode ser vazia.");

            RuleFor(x => x.Price)
                .NotEmpty()
                .WithMessage("O preço deve estar preenchido.");

            RuleFor(x => x.Amount)
                .NotEmpty()
                .WithMessage("A quantidade deve ser inforamda.");

            RuleFor(x => x.Name)
                .MaximumLength(150)
                .WithMessage("O nome do produto não pode conter mais que 150 caracteres.");

            RuleFor(x => x.Description)
                .MaximumLength(200)
                .WithMessage("A descrição não pode conter mais que 200 caracteres");

            RuleFor(x => x.Amount)
                .LessThanOrEqualTo(0)
                .WithMessage("A quantidade em estoque deve ser maior que 0");

            

        }

        
    }
}
