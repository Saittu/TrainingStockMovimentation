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
                Date = dto.Created_At
            };

            _repository.CreateStockMovement(entity);
        }

        public void DeleteStockMovement(long id)
        {
            _repository.DeleteStockMovement(id);
        }

        public List<StockMovementGridDto> GetStockMovementGrids()
        {
            var entity = _repository.GetStockMovementList();

            return entity.Select(x => new StockMovementGridDto
            {
                MovimentType = x.Type,
                Created_At = x.Date
            }).ToList();
        }

        public void UpdateStockMovemnt(long id, CreateStockMovementDto dto)
        {
            _validator.Validate(dto);

            var entity = new StockMovement { Type = dto.MovimentType };

            _repository.UpdateStockMovement(id, entity);
        }
    }
}
