using TrainingStockMovimentation.Domain.Enums;

namespace TrainingStockMovimentation.Domain.Entitys
{
    public class StockMovementView
    {
        public long Id { get; set; }

        public MovimentType EntradaOuSaidaValor { get; set; }

        public DateTime DataMovimentacao { get; set; }

        public decimal ValueMovimentation { get; set; }

        public int QuantidadeMovimentadaProduto { get; set; }

        public string NomeProduto { get; set; }

        public string? Description { get; set; }

        public CategoryProduct TipoProduto { get; set; }

        public int QuantidadeRestanteEmEstoque { get; set; }

        public string NomeConta { get; set; }

        public int NumeroConta { get; set; }

        public decimal SaldoRestante { get; set; }
    }
}
