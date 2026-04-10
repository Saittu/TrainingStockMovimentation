using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
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
            _context.Database.ExecuteSqlRaw(
                 "EXEC sp_MovimentacaoEstoque @ProductId, @Type, @Date, @QuantityProduct, @ContaId",
                     new SqlParameter("@ProductId", entity.ProductId),
                     new SqlParameter("@Type", entity.Type),
                     new SqlParameter("@Date", entity.Date),
                     new SqlParameter("@QuantityProduct", entity.QuantityProduct),
                     new SqlParameter("@ContaId", entity.ContaId)
             );
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

        public StockMovementView GetStockMovementView(long id)
        {
            var response = _context.StockMovementViews.FirstOrDefault(x => x.Id == id);

            if (response is null)
                throw new Exception("Falha em retornar os dados do registro selecionado em movimentações de estoque.");

            return response;
        }
    }
}
