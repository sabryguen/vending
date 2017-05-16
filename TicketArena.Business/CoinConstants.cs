namespace TicketArena.Business
{
    public class CoinConstants
    {
        // Don't shoot me if these values are not correct, they were pulled from wikipedia :-)

        // Nickel = 5 cents        
        // Value 0.05 U.S.dollar
        // Mass	5.000 g
        // Diameter	21.21mm
        public const decimal NickelWeight = 5.000m;
        public const decimal NickelDiameter = 21.21m;
        public const decimal NickelMonetaryValue = 0.05m;
        
        // Dime
        // Value 0.10 U.S.dollar
        // Mass	2.268g
        // Diameter	17.91mm
        public const decimal DimeWeight = 2.268m;
        public const decimal DimeDiameter = 17.91m;
        public const decimal DimeMonetaryValue = 0.10m;

        // Quarter
        // Value 0.25 U.S.Dollar
        // Mass	5.670g
        // Diameter	24.26mm
        public const decimal QuarterWeight = 5.670m;
        public const decimal QuarterDiameter = 24.26m;
        public const decimal QuarterMonetaryValue = 0.25m;

        // Half dollar
        // Value 0.50 U.S.dollar
        // Mass	11.340 g
        // Diameter	30.61 mm
        public const decimal HalfDollarWeight = 11.340m;
        public const decimal HalfDollarDiameter = 30.61m;
        public const decimal HalfDollarMonetaryValue = 0.50m;

        // Dollar
        // Value 1.00 U.S.dollar
        // Mass	8.100g
        // Diameter	26.5 mm
        public const decimal DollarWeight = 8.100m;
        public const decimal DollarDiameter = 26.5m;
        public const decimal DollarMonetaryValue = 1.00m;
    }
}
