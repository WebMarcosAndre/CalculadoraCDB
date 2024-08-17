namespace Investment.Domain.CalculateTaxStrategy
{
    public class CalculateTaxUpTo24Months : CalculateTaxStrategyBase
    {
        private const decimal taxRate = 0.175m;
        public decimal Calculate(decimal grossAmount)
        {
            return grossAmount * taxRate;
        }

        public bool Match(int termInMonths)
        {
            return termInMonths <= 24;
        }
    }
}
