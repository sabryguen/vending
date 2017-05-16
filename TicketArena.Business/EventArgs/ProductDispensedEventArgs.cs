using TicketArena.Domain;

namespace TicketArena.Business.EventArgs
{
    public class ProductDispensedEventArgs : System.EventArgs
    {
        public Product DispensedProduct { get; set; }
    }
}
