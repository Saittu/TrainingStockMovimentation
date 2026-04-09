using FluentValidation;
using TrainingStockMovimentation.Application.DTO.StockMovement;

namespace TrainingStockMovimentation.Application.Validators.StockMovement
{
    public class StockMovementValidatorDto : AbstractValidator<CreateStockMovementDto>
    {
        public StockMovementValidatorDto()
        {
            RuleFor(x => x.MovimentType)
                .NotEmpty()
                .WithMessage("É obrigatório ter um tipo de movimento de estoque.");

            RuleSet("Create", () =>
            {
                RuleFor(x => x.Created_At)
                    .NotEmpty()
                    .WithMessage("A data de criação do movimento de estoque é obrigatória");

            });
        }
    }
}
