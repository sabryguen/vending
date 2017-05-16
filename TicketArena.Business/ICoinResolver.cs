using TicketArena.Domain;

namespace TicketArena.Business
{
    public interface ICoinResolver
    {
        Coin ResolveCoin(decimal weightGrams, decimal diameter);
    }
}
