using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingStockMovimentation.Domain.Enums;

namespace TrainingStockMovimentation.Application.DTO.StockMovement
{
    public class UpdateStockMovementDto
    {
        public MovimentType Type { get; set; }
    }
}
