using TrainingStockMovimentation.Application.DTO.ContaBC;

namespace TrainingStockMovimentation.Application.Interfaces
{
    public interface IContaBCService
    {
        List<ContaBCGridDto> GetAllContaBcGrid(FilterContaBCDto filter);

        ContaBCDto GetContaBC(long id);

        void CreateContaBC(ContaBCDto contabc);

        void DeleteContaBC(long id);

        void UpdateContaBC(long id, ContaBCUpdateDto contaBC);
    }
}
