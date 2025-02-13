using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonClasses.Models
{
    public class RateChangeEvent
    {
        public string Symbol { get; set; }
        public decimal OldRate { get; set; }
        public decimal NewRate { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
