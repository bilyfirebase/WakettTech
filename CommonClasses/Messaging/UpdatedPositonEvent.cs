using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonClasses.Messaging
{
    public class UpdatedPositonEvent
    {
        public string InstrumentId { get; set; }
        public decimal NewProfitLoss { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
