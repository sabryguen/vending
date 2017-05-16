using TicketArena.Domain;

namespace TicketArena.Business.EventArgs
{
    public class CoinReturnedEventArgs : System.EventArgs
    {
        public Coin ReturnedCoin { get; set; }
    }
}
