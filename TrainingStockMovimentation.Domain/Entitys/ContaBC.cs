namespace TrainingStockMovimentation.Domain.Entitys
{
    public class ContaBC
    {
        public ContaBC() { }

        public long Id { get; set; }

        public string Name { get; set; }

        public int Number { get; set; }

        public decimal? Balance { get; set; }

        public bool FlContaAtiva { get; set; }

        public List<StockMovement> StockMovement { get; set; } = new List<StockMovement>();
    }
}
