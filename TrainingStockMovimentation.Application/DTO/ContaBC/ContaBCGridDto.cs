using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingStockMovimentation.Application.DTO.ContaBC
{
    public class ContaBCGridDto
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public int Number { get; set; }

        public decimal? Balance { get; set; }

        public bool FlContaAtiva { get; set; }
    }
}
