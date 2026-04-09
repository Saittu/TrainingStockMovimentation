using TrainingStockMovimentation.Domain.Enums;

namespace TrainingStockMovimentation.Domain.Entitys
{
    public class Supplier
    {
        public Supplier() { }

        public Supplier(string name)
        {
            Name = name;
        }

        public long Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string CNPJ {  get; set; } = string.Empty;

        public CategoryProduct ProductCategory { get; set; }

        public List<Products>? Products { get; set; } = new List<Products>();
    }
}
