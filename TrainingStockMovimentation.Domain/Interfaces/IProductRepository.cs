using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingStockMovimentation.Domain.Entitys;

namespace TrainingStockMovimentation.Domain.Interfaces
{
    public interface IProductRepository
    {
        Products GetProducts(long id);

        void CreateProduct(Products products);

        void UpdateProduct(long id, Products products);

        void DeleteProduct(long id);

        bool ValidaProdutoVinculadoEstoque(long id);
    }
}
