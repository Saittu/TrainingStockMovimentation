using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingStockMovimentation.Domain.Entitys;
using TrainingStockMovimentation.Domain.Interfaces;
using TrainingStockMovimentation.Infra.Database.Context;

namespace TrainingStockMovimentation.Infra.Repository
{
    public class StockMovementRepository : IStockMovementRepository
    {
        private readonly AppDbContext _context;

        public StockMovementRepository(AppDbContext context)

        {
            _context = context;
        }

        public void CreateStockMovement(StockMovement entity)
        {
            _context.StockMovement.Add(entity);
            _context.SaveChanges();
        }

        public void DeleteStockMovement(long id)
        {
            var stockMovementDb = _context.StockMovement.FirstOrDefault(x => x.Id == id);

            if (stockMovementDb is null)
                throw new Exception("Falha ao excluir movimento de estoque");

            _context.StockMovement.Remove(stockMovementDb);
            _context.SaveChanges();
        }

        public List<StockMovement> GetStockMovementList()
        {
            var response = _context.StockMovement.OrderBy(x => x.Id).ToList();

            return response;
        }

        public void UpdateStockMovement(long id, StockMovement entity)
        {
            var stockMovementId = _context.StockMovement.FirstOrDefault(x => x.Id == id);

            if (stockMovementId is null)
                throw new Exception("Erro ao atualizar o tipo de movimentação de estoque.");

            stockMovementId.Type = entity.Type;

            _context.SaveChanges();
        }
    }
}
