namespace Investment.Domain.CalculateTaxStrategy
{
    public class CalculateTaxUpTo12Months : CalculateTaxStrategyBase
    {
        private const decimal taxRate = 0.20m;
        public decimal Calculate(decimal grossAmount)
        {
            return grossAmount * taxRate;
        }

        public bool Match(int termInMonths)
        {
            return termInMonths <= 12;
        }
    }
}
