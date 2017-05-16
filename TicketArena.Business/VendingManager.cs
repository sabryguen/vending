using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using TicketArena.Business.EventArgs;
using TicketArena.Domain;

namespace TicketArena.Business
{
    public class VendingManager
    {
        private readonly ICoinResolver _coinResolver;
        private readonly IChangeDispenser _changeDispenser;

        private Product _selectedProduct;
        private readonly Stack<Coin> _coins;

        public event EventHandler<CoinReturnedEventArgs> CoinReturned;
        public event EventHandler<UnrecognisedCoinReturnedEventArgs> UnrecognisedCoinReturned;
        public event EventHandler<ProductDispensedEventArgs> ProductDispensed;
        public event EventHandler<DisplayEventArgs> DisplayUpdated;
        public event EventHandler<AmountEventArgs> AmountUpdated;
        
        public VendingManager(ICoinResolver coinResolver, IChangeDispenser changeDispenser)
        {
            _coinResolver = coinResolver;
            _changeDispenser = changeDispenser;
            _coins = new Stack<Coin>();
        }

        public void SelectProduct(Product selectedProduct)
        {
            _selectedProduct = selectedProduct;
        }

        public void AddCoin(decimal weightGrams, decimal diameter)
        {
            if (_selectedProduct == null)
            {
                DisplayEventArgs displayEventArgs = new DisplayEventArgs { Message = "PLEASE CHOOSE A PRODUCT" };
                OnDisplayUpdated(displayEventArgs);
                return;
            }

            Coin aCoin = _coinResolver.ResolveCoin(weightGrams, diameter);

            if(aCoin != null)
            { 
                _coins.Push(aCoin);

                decimal sum = _coins.Sum(x => x.MonetaryValue);

                AmountEventArgs amountArgs = new AmountEventArgs {Amount = sum };
                OnAmountUpdated(amountArgs);
                
                // Check if we have sufficient funds to dispense the selected product
                if (_selectedProduct.Cost <= sum)
                {
                    // update the display
                    DisplayEventArgs displayEventArgs = new DisplayEventArgs { Message = "THANK YOU" };
                    OnDisplayUpdated(displayEventArgs);

                    // raise an event to show that the product has been dispensed.
                    ProductDispensedEventArgs productArgs =
                        new ProductDispensedEventArgs {DispensedProduct = _selectedProduct};
                    OnProductDispensed(productArgs);

                    // calculate the change due to the buyer and fire an event for each coin that the 
                    // buyer will receive back. 
                    var changeDue = sum - _selectedProduct.Cost;
                    List<Coin> changeCoins = _changeDispenser.DispenseChange(changeDue);
                    
                    // Fire an event for each change coin.
                    if (changeCoins != null)
                    {                    
                        foreach (var changeCoin in changeCoins)
                        { 
                            CoinReturnedEventArgs args = new CoinReturnedEventArgs { ReturnedCoin = changeCoin };
                            OnCoinReturned(args);
                        }
                    }

                    // reset the amount
                    AmountEventArgs resetAmountArgs = new AmountEventArgs { Amount = 0.00m };
                    OnAmountUpdated(resetAmountArgs);
                    
                    // Give the consumer chance to update the display - This is of course optional 
                    // and really only added for the demo so that you can clearly see on the test client that Thank you is displayed for
                    // a short while before reverting to INSERT COIN.
                    Thread.Sleep(3500);

                    // Start again!
                    DisplayEventArgs displayEventArgsReset = new DisplayEventArgs { Message = "INSERT COIN" };
                    OnDisplayUpdated(displayEventArgsReset);
                    
                    // clear the stack ready for the next transaction.
                    _coins.Clear();
                }
                else
                {
                    DisplayEventArgs displayInstructionEventArgs = new DisplayEventArgs { Message = "PRICE" };
                    OnDisplayUpdated(displayInstructionEventArgs);

                    // Again, facilitates the buyer seeing the Price text before the price of the product is displayed.
                    Thread.Sleep(500);

                    DisplayEventArgs displayProductPriceEventArgs = new DisplayEventArgs
                    {
                        Message = _selectedProduct.Cost.ToString(CultureInfo.InvariantCulture)
                    };

                    OnDisplayUpdated(displayProductPriceEventArgs);
                }
            }
            else
            {
                // raise an event to return the unrecognised coin.
                UnrecognisedCoinReturnedEventArgs args =
                    new UnrecognisedCoinReturnedEventArgs
                    {
                        Message = "Coin not accepted",
                        CoinWeight = weightGrams,
                        CointDiameter = diameter
                    };

                OnUnrecognisedCoinReturned(args);
            }
        }

        public void CancelOrder()
        {
            if (_coins.Count > 0)
            {
                while(_coins.Count > 0)
                { 
                    Coin aCoin = _coins.Pop();
                    CoinReturnedEventArgs args = new CoinReturnedEventArgs { ReturnedCoin = aCoin };
                    OnCoinReturned(args);
                }
            }

            // Start again!
            DisplayEventArgs displayEventArgsReset = new DisplayEventArgs { Message = "INSERT COIN" };
            OnDisplayUpdated(displayEventArgsReset);

            // clear the stack ready for the next transaction.
            _coins.Clear();

            // reset the amount
            AmountEventArgs resetAmountArgs = new AmountEventArgs { Amount = 0.00m };
            OnAmountUpdated(resetAmountArgs);
        }

        public virtual void OnAmountUpdated(AmountEventArgs e)
        {
            AmountUpdated?.Invoke(this, e);
        }

        public virtual void OnDisplayUpdated(DisplayEventArgs e)
        {
            DisplayUpdated?.Invoke(this, e);
        }

        public virtual void OnProductDispensed(ProductDispensedEventArgs e)
        {
            ProductDispensed?.Invoke(this, e);
        }

        public virtual void OnUnrecognisedCoinReturned(UnrecognisedCoinReturnedEventArgs e)
        {
            UnrecognisedCoinReturned?.Invoke(this, e);
        }

        public virtual void OnCoinReturned(CoinReturnedEventArgs e)
        {
            CoinReturned?.Invoke(this, e);
        }
    }
}
