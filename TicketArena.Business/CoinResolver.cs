using TicketArena.Domain;

namespace TicketArena.Business
{
    public class CoinResolver : ICoinResolver
    {
        /// <summary>
        /// This method is designed to resolve Nickel, Dime, Quarter, Half Dollar and Dollar coins        
        /// </summary>
        /// <param name="weightGrams">The coin weight</param>
        /// <param name="diameter">The coin diameter</param>
        /// <returns>a coin object populated with monetary value or null if the weight and diameter don't match the resolution values</returns>
        public Coin ResolveCoin(decimal weightGrams, decimal diameter)
        {
            // Guard against the silly values, negative weights, negative diameters.
            // ideally, there would be a validator step to ensure that these were sane values but since this
            // is an exercise, I've left this out. Equally we could just drop through the checks below and still return null
            // but I just wanted to demonstrate that this class could potentially have an IValidator injected to catch silly values.
            if (weightGrams < 0 || diameter < 0)
            {
                return null;
            }

            // This is very crude and could be done using a factory but for the purposes of the simulation, it is good enough.
            // Note that this also assumes that the machine can get the diameter of the coin to very good precision, in practice
            // I'm sure that tolerances will apply and coins would be rejected but for the simulation those requirements haven't been 
            // considered nor specified.

            if (weightGrams == CoinConstants.NickelWeight && diameter == CoinConstants.NickelDiameter)
            {
                // Nickel = 5 cents        
                // Value 0.05 U.S.dollar
                // Mass	5.000 g
                // Diameter	21.21mm
                return new Coin("Nickel", CoinConstants.NickelWeight, CoinConstants.NickelDiameter, CoinConstants.NickelMonetaryValue);
            }

            if (weightGrams == CoinConstants.DimeWeight && diameter == CoinConstants.DimeDiameter)
            {
                return new Coin("Dime", CoinConstants.DimeWeight, CoinConstants.DimeDiameter, CoinConstants.DimeMonetaryValue);
            }

            if (weightGrams == CoinConstants.QuarterWeight && diameter == CoinConstants.QuarterDiameter)
            {
                return new Coin("Quarter", CoinConstants.QuarterWeight, CoinConstants.QuarterDiameter, CoinConstants.QuarterMonetaryValue);
            }

            if (weightGrams == CoinConstants.HalfDollarWeight && diameter == CoinConstants.HalfDollarDiameter)
            {
                return new Coin("Half Dollar", CoinConstants.HalfDollarWeight, CoinConstants.HalfDollarDiameter, CoinConstants.HalfDollarMonetaryValue);
            }

            if (weightGrams == CoinConstants.DollarWeight && diameter == CoinConstants.DollarDiameter)
            {
                return new Coin("Dollar", CoinConstants.DollarWeight, CoinConstants.DollarDiameter, CoinConstants.DollarMonetaryValue);
            }

            // We don't recognise the coin so return null.
            return null;
        }
    }
}
