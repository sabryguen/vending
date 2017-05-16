using System.Collections.Generic;
using TicketArena.Domain;

namespace TicketArena.Business
{
    public interface IChangeDispenser
    {
        /// <summary>
        /// Given a change amount, this will return the coins is the various denominations
        /// </summary>
        /// <param name="amount">the total amount of change</param>
        /// <returns>a collection of coins ordered by highest denomination value first or null if no change is due</returns>
        List<Coin> DispenseChange(decimal amount);
    }
}
