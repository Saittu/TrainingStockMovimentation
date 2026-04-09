using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingStockMovimentation.Domain.Enums
{
    public enum CategoryProduct
    {
        [Description("Eletronicos")]
        Eletronico = 1,

        [Description("Saude e beleza")]
        SaudeBeleza = 2,

        [Description("Casa e cozinha")]
        CasaCozinha = 3,

        [Description("Alimenticios")]
        Alimenticios = 4,

        [Description("Quarto")]
        Quarto = 5
    }
}
