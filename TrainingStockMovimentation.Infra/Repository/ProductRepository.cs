using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using TrainingStockMovimentation.Domain.Entitys;
using TrainingStockMovimentation.Domain.Interfaces;
using TrainingStockMovimentation.Infra.Database.Context;

namespace TrainingStockMovimentation.Infra.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public void CreateProduct(Products products)
        {
            _context.Products.Add(products);
            _context.SaveChanges();
        }

        public void DeleteProduct(long id)
        {
            var productDb = _context.Products.FirstOrDefault(x => x.Id == id);

            if (productDb is null)
                throw new Exception("Erro ao excluir produto");

            _context.Products.Remove(productDb);
            _context.SaveChanges();

        }

        public Products GetProducts(long id)
        {
            var produto = _context.Products.FirstOrDefault(x => x.Id == id);

            if (produto is null)
                throw new Exception("Erro ao trazer o produto");

            return produto;
        }

        public void UpdateProduct(long id, Products products)
        {
            var productDb = _context.Products.FirstOrDefault(x => x.Id == id);

            if (productDb is null)
                throw new Exception("Erro ao atualizar produtos.");

            productDb.Name = products.Name.IsNullOrEmpty() ? productDb.Name : products.Name;
            productDb.Description = products.Description.IsNullOrEmpty() ? productDb.Description : products.Description;
            productDb.Price = products.Price != 0 ? products.Price : productDb.Price;
            productDb.Amount = products.Amount != 0 ? products.Amount : productDb.Amount;
            productDb.Type = products.Type != 0 ? products.Type : productDb.Type;
            productDb.SupplierId = productDb.SupplierId;


            _context.SaveChanges();
        }


        public bool ValidaProdutoVinculadoEstoque(long id)
        {
            var vinculadoEstoque = $@"
                SELECT 
                SM.* 
                FROM Products P
                INNER JOIN StockMovement SM ON SM.ProductId = P.Id
                WHERE P.Id = @IdProduto
            ";

            var parametros = new SqlParameter("@IdProduto", id);

            var response = _context.StockMovement.FromSqlRaw(vinculadoEstoque, parametros).AsNoTracking().FirstOrDefault();

            if (response != null)
                return false;

            return true;
        }
    }
}
