using System.ComponentModel;

namespace TrainingStockMovimentation.Domain.Enums
{
    public enum MovimentType
    {
        [Description("Entrada")]
        Entrada = 1,

        [Description("Saida")]
        Saida = 2
    }
}
