using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonClasses.Models
{
    public class InstrumentRate
    {
        public string Symbol { get; set; }  // e.g., BTC
        public decimal Rate { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
