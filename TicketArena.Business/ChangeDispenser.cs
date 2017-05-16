using System;
using System.Collections.Generic;
using TicketArena.Domain;

namespace TicketArena.Business
{
    public class ChangeDispenser : IChangeDispenser
    {
        public List<Coin> DispenseChange(decimal amount)
        {
            
            if (amount <= 0)
            {
                // nothing to do here
                return null;
            }

            int numDollars = 0;
            int numHalfDollars = 0;
            int numQuarters = 0;
            int numDimes = 0;
            int numNickels = 0;
            
            List<Coin> coins = new List<Coin>();

            if (amount >= CoinConstants.DollarMonetaryValue)
            {
                numDollars = (int) (amount / CoinConstants.DollarMonetaryValue);
                amount = amount % CoinConstants.DollarMonetaryValue;
            }

            if (amount >= CoinConstants.HalfDollarMonetaryValue)
            {
                numHalfDollars = (int)(amount / CoinConstants.HalfDollarMonetaryValue);
                amount = amount % CoinConstants.HalfDollarMonetaryValue;
            }

            if (amount >= CoinConstants.QuarterMonetaryValue)
            {
                numQuarters = (int)(amount / CoinConstants.QuarterMonetaryValue);
                amount = amount % CoinConstants.QuarterMonetaryValue;
            }

            if (amount >= CoinConstants.DimeMonetaryValue)
            {
                numDimes = (int)(amount / CoinConstants.DimeMonetaryValue);
                amount = amount % CoinConstants.DimeMonetaryValue;
            }

            if (amount >= CoinConstants.NickelMonetaryValue)
            {
                numNickels = (int)(amount / CoinConstants.NickelMonetaryValue);
                amount = amount % CoinConstants.NickelMonetaryValue;
            }
            
            // we expect amount to be zero at this point.
            // Note that the smallest coin we handle is a nickel. This is an assumption of course. maybe vending machines handle 
            // pennies but I've assumed that this is rare so I've gone with 0.05 as the smallest coin accepted.
            if (amount != 0)
            {
                throw new ArgumentException($"{amount} remaining due to initial value not handled by smallest denomination");
            }
            
            Console.WriteLine($"Dollars: {numDollars}, Half Dollars : {numHalfDollars}, Quarters : {numQuarters}, Dimes : {numDimes}, Nickels: {numNickels}");

            for(int i=0; i<numDollars; i++)
            {
                coins.Add(new Coin("Dollar", CoinConstants.DollarWeight, CoinConstants.DollarDiameter, CoinConstants.DollarMonetaryValue));
            }

            for (int i = 0; i < numHalfDollars; i++)
            {
                coins.Add(new Coin("Half Dollar", CoinConstants.HalfDollarWeight, CoinConstants.HalfDollarDiameter, CoinConstants.HalfDollarMonetaryValue));
            }

            for (int i = 0; i < numQuarters; i++)
            {
                coins.Add(new Coin("Quarter", CoinConstants.QuarterWeight, CoinConstants.QuarterDiameter, CoinConstants.QuarterMonetaryValue));
            }

            for (int i = 0; i < numDimes; i++)
            {
                coins.Add(new Coin("Dime", CoinConstants.DimeWeight, CoinConstants.DimeDiameter, CoinConstants.DimeMonetaryValue));
            }

            for (int i = 0; i < numNickels; i++)
            {
                coins.Add(new Coin("Nickel", CoinConstants.NickelWeight, CoinConstants.NickelDiameter, CoinConstants.NickelMonetaryValue));
            }

            return coins;
        }
    }
}
