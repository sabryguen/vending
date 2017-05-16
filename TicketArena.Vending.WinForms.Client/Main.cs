using System;
using System.Linq;
using System.Windows.Forms;
using TicketArena.Business;
using TicketArena.Domain;

namespace TicketArena.Vending.WinForms.Client
{
    public partial class Main : Form
    {
        private readonly VendingManager _vendingManager;

        public Main()
        {
            InitializeComponent();

            ICoinResolver coinResolver = new CoinResolver();
            IChangeDispenser changeDispenser = new ChangeDispenser();

            // Initialise state on the radio buttons with the coin properties
            rbNickel.Tag = new Tuple<decimal,decimal>(CoinConstants.NickelWeight, CoinConstants.NickelDiameter);
            rbDime.Tag = new Tuple<decimal, decimal>(CoinConstants.DimeWeight, CoinConstants.DimeDiameter);
            rbQuarter.Tag = new Tuple<decimal, decimal>(CoinConstants.QuarterWeight, CoinConstants.QuarterDiameter);
            rbHalfDollar.Tag = new Tuple<decimal, decimal>(CoinConstants.HalfDollarWeight, CoinConstants.HalfDollarDiameter);
            rbDollar.Tag = new Tuple<decimal, decimal>(CoinConstants.DollarWeight, CoinConstants.DollarDiameter);
            rbDummyCoin.Tag = new Tuple<decimal, decimal>(20m, 30m);
            
            // Initialise state for the products on the product radio buttons.
            rbCola.Tag = new Product("Cola", 1.00m);
            rbChips.Tag = new Product("Chips", 0.50m);
            rbCandy.Tag = new Product("Candy", 0.65m);
            
            _vendingManager = new VendingManager(coinResolver, changeDispenser);
            _vendingManager.AmountUpdated += _vendingManager_AmountUpdated;
            _vendingManager.CoinReturned += _vendingManager_CoinReturned;
            _vendingManager.DisplayUpdated += _vendingManager_DisplayUpdated;
            _vendingManager.ProductDispensed += _vendingManager_ProductDispensed;
            _vendingManager.UnrecognisedCoinReturned += _vendingManager_UnrecognisedCoinReturned;
        }

        private void _vendingManager_UnrecognisedCoinReturned(object sender, Business.EventArgs.UnrecognisedCoinReturnedEventArgs e)
        {
            rtbEvents.AppendText($"Message:{e.Message}, Weight:{e.CoinWeight}, Diameter:{e.CointDiameter}\r\n");
        }

        private void _vendingManager_ProductDispensed(object sender, Business.EventArgs.ProductDispensedEventArgs e)
        {
            rtbEvents.AppendText($"Product {e.DispensedProduct.Name} dispensed.\r\n");
            ResetUiState();
        }

        private void _vendingManager_DisplayUpdated(object sender, Business.EventArgs.DisplayEventArgs e)
        {
            lblDisplay.Text = e.Message;
            Refresh();
        }

        private void _vendingManager_CoinReturned(object sender, Business.EventArgs.CoinReturnedEventArgs e)
        {
            rtbEvents.AppendText($"Coin returned:{e.ReturnedCoin.Name}\r\n");
        }

        private void _vendingManager_AmountUpdated(object sender, Business.EventArgs.AmountEventArgs e)
        {
            lblAmount.Text = e.Amount.ToString("F");
            Refresh();
        }

        private void btnAddCoin_Click(object sender, EventArgs e)
        {
            RadioButton rb = GetCheckedRadioButton();
            Tuple<decimal, decimal> coinProperties = rb.Tag as Tuple<decimal, decimal>;

            if(coinProperties != null)
            { 
                _vendingManager.AddCoin(coinProperties.Item1, coinProperties.Item2);
            }
        }

        private RadioButton GetCheckedRadioButton()
        {
            var button = gbCoins.Controls.OfType<RadioButton>()
                .FirstOrDefault(n => n.Checked);

            return button;
        }

        private void ResetUiState()
        {
            // Reset the state of the UI
            rbCandy.Checked = false;
            rbCola.Checked = false;
            rbChips.Checked = false;

            rbNickel.Checked = true;

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _vendingManager.CancelOrder();

            ResetUiState();
        }

        private void rbCola_CheckedChanged(object sender, EventArgs e)
        {
            if(rbCola.Checked)
            { 
                _vendingManager.SelectProduct((Product)rbCola.Tag);
            }
        }

        private void rbChips_CheckedChanged(object sender, EventArgs e)
        {
            if (rbChips.Checked)
            { 
                _vendingManager.SelectProduct((Product)rbChips.Tag);
            }
        }

        private void rbCandy_CheckedChanged(object sender, EventArgs e)
        {
            if (rbCandy.Checked)
            { 
                _vendingManager.SelectProduct((Product)rbCandy.Tag);
            }
        }
    }
}
