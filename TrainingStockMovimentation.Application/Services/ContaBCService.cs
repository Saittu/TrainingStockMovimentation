using TrainingStockMovimentation.Application.DTO.ContaBC;
using TrainingStockMovimentation.Application.Interfaces;
using TrainingStockMovimentation.Domain.Entitys;
using TrainingStockMovimentation.Domain.Interfaces;

namespace TrainingStockMovimentation.Application.Services
{
    public class ContaBCService : IContaBCService
    {
        private readonly IContaBCRepository _repository;

        public ContaBCService(IContaBCRepository repository)
        {
            _repository = repository;
        }

        public void CreateContaBC(ContaBCDto contabc)
        {
            var conta = new ContaBC
            {
                Id = 0,
                Name = contabc.Name,
                Number = contabc.Number,
                FlContaAtiva = contabc.FlContaAtiva,
                Balance = 0
            };

            _repository.CreateContaBC(conta);
        }

        public void DeleteContaBC(long id)
        {
            _repository.DeleterContaBC(id);
        }

        public List<ContaBCGridDto> GetAllContaBcGrid(FilterContaBCDto filter)
        {
            var entity = _repository.GetAll().AsQueryable();

            if (filter.FlContaAtiva.HasValue)
                entity = entity.Where(x => x.FlContaAtiva == filter.FlContaAtiva.Value);

            var retorno = entity.Select(x => new ContaBCGridDto
            {
                Id = x.Id,
                Name = x.Name,
                Number = x.Number,
                Balance = x.Balance,
                FlContaAtiva = x.FlContaAtiva
            }).ToList();

            return retorno;
        }

        public ContaBCDto GetContaBC(long id)
        {
            var response = _repository.GetConta(id);

            return new ContaBCDto
            {
                Name = response.Name,
                Number = response.Number,
                FlContaAtiva = response.FlContaAtiva
            };
        }

        public void UpdateContaBC(long id, ContaBCUpdateDto contaBC)
        {
            var entity = _repository.GetConta(id);

            if (entity is null)
                throw new Exception("Conta não encontrada");

            if (!string.IsNullOrEmpty(contaBC.Name))
                entity.Name = contaBC.Name;

            if (contaBC.Number.HasValue)
                entity.Number = contaBC.Number.Value;

            if (contaBC.FlContaAtiva.HasValue)
                entity.FlContaAtiva = contaBC.FlContaAtiva.Value;

            _repository.UpdateContaBC(entity);
        }
    }
}
