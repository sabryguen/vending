using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketArena.Business.EventArgs
{
    public class UnrecognisedCoinReturnedEventArgs : System.EventArgs
    {
        public string Message { get; set; }

        public decimal CointDiameter { get; set; }

        public decimal CoinWeight { get; set; }
    }
}
