namespace TicketArena.Domain
{
    public class Coin
    {
        public Coin(string name, decimal mass, decimal diameter, decimal value)
        {
            Name = name;
            MassGrams = mass;
            DiameterMm = diameter;
            MonetaryValue = value;
        }

        /// <summary>
        /// The common name for the coin    
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The mass of the coin in grams
        /// </summary>
        public decimal MassGrams { get; set; }

        /// <summary>
        /// The diameter of the coin - this will be used to simulate the size.
        /// </summary>
        public decimal DiameterMm { get; set; }

        public decimal MonetaryValue { get; }
    }
}
