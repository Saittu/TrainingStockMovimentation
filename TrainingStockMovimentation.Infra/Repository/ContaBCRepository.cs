using Microsoft.IdentityModel.Tokens;
using TrainingStockMovimentation.Domain.Entitys;
using TrainingStockMovimentation.Domain.Interfaces;
using TrainingStockMovimentation.Infra.Database.Context;

namespace TrainingStockMovimentation.Infra.Repository
{
    public class ContaBCRepository : IContaBCRepository
    {
        private readonly AppDbContext _context;

        public ContaBCRepository(AppDbContext context)
        {
            _context = context;
        }

        public void CreateContaBC(ContaBC conta)
        {
            _context.ContaBC.Add(conta);
            _context.SaveChanges();
        }

        public void DeleterContaBC(long id)
        {
            var contabc = _context.ContaBC.FirstOrDefault(x => x.Id == id);

            if (contabc is null)
                throw new Exception("Falha ao excluir conta.");

            _context.ContaBC.Remove(contabc);
            _context.SaveChanges();
        }

        public List<ContaBC> GetAll()
        {
            var contaBC = _context.ContaBC.OrderBy(c => c.Id).ToList();

            return contaBC;
        }

        public ContaBC GetConta(long id)
        {
            var entity = _context.ContaBC.FirstOrDefault(x => x.Id == id);

            if (entity is null)
                throw new Exception("Falha ao trazer os dados da conta.");

            return entity;
        }

        public void UpdateContaBC(ContaBC conta)
        {
            _context.SaveChanges();
        }
    }
}
