namespace TicketArena.Domain
{
    public class Product
    {
        public Product(string name, decimal cost)
        {
            Name = name;
            Cost = cost;
        }

        /// <summary>
        /// The product name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The monetary value of the product
        /// </summary>
        public decimal Cost { get; set; }
    }
}
