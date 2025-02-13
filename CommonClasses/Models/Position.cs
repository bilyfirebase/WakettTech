using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonClasses.Enums;

namespace CommonClasses.Models
{
    public class Position
    {
        public string InstrumentId { get; set; }
        public decimal Quantity { get; set; }
        public decimal InitialRate { get; set; }
        public PositionSide Side { get; set; }

        public decimal CalculateProfitOrLoss(decimal currentRate)
        {
            return Quantity * (currentRate - InitialRate) * (Side == PositionSide.Buy ? 1 : -1);
        }
    }
}
