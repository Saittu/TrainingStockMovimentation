using FluentValidation;
using TrainingStockMovimentation.Application.DTO.StockMovement;
using TrainingStockMovimentation.Application.Interfaces;
using TrainingStockMovimentation.Domain.Entitys;
using TrainingStockMovimentation.Domain.Interfaces;

namespace TrainingStockMovimentation.Application.Services
{
    public class StockMovementService : IStockMovementService
    {
        private readonly IStockMovementRepository _repository;
        private readonly IValidator<CreateStockMovementDto> _validator;

        public StockMovementService(IStockMovementRepository repository, IValidator<CreateStockMovementDto> validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public void CreateStockMovemnt(long prodcutId, CreateStockMovementDto dto)
        {
            _validator.Validate(dto, options => options.IncludeRuleSets("Create")) ;

            var entity = new StockMovement
            {
                ProductId = prodcutId,
                Type = dto.MovimentType,
                Date = dto.Created_At,
                ValueMovimentation = 0,
                QuantityProduct = dto.QuantityProduct,
                ContaId = dto.ContaId,
            };

            _repository.CreateStockMovement(entity);
        }

        public void DeleteStockMovement(long id)
        {
            _repository.DeleteStockMovement(id);
        }

        public StockMovementDto GetStockMovement(long id)
        {
            var view = _repository.GetStockMovementView(id);

            return new StockMovementDto
            {
                Id = view.Id,
                EntradaOuSaidaValor = view.EntradaOuSaidaValor,
                DataMovimentacao = view.DataMovimentacao,
                ValueMovimentation = view.ValueMovimentation,
                QuantidadeMovimentadaProduto = view.QuantidadeMovimentadaProduto,
                NomeProduto = view.NomeProduto,
                Description = view.Description,
                TipoProduto = view.TipoProduto,
                QuantidadeRestanteEmEstoque = view.QuantidadeRestanteEmEstoque,
                NomeConta = view.NomeConta,
                NumeroConta = view.NumeroConta,
                SaldoRestante = view.SaldoRestante
            };
        }

        public List<StockMovementGridDto> GetStockMovementGrids()
        {
            var entity = _repository.GetStockMovementList();

            return entity.Select(x => new StockMovementGridDto
            {
                MovimentType = x.Type,
                Created_At = x.Date,
                ValueMovimentation = x.ValueMovimentation,
                QuantityProduct = x.QuantityProduct
            }).ToList();
        }
    }
}
