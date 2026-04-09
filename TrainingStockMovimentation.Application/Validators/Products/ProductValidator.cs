using FluentValidation;
using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingStockMovimentation.Application.DTO.Products;
using TrainingStockMovimentation.Domain.Entitys;
using TrainingStockMovimentation.Domain.Interfaces;

namespace TrainingStockMovimentation.Application.Validators.Products
{
    public class ProductValidator : AbstractValidator<long>
    {
        private readonly IProductRepository _repository;

        public ProductValidator(IProductRepository repository) 
        {
            _repository = repository;

            RuleFor(x => x)
                .Must(ValidaProdutoVinculadoEstoque)
                .WithMessage("Não é possivel apagar o produto pois o mesmo se encontra vinculado a uma movimentação de estoque.");
        }

        private bool ValidaProdutoVinculadoEstoque(long id)
        {
            var verificaVinculos = _repository.ValidaProdutoVinculadoEstoque(id);

            if (!verificaVinculos)
                return false;

            return true;
        }
    }
}
