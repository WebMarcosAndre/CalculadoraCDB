using Investment.Domain.CalculateTaxStrategy;

namespace Investment.Domain.Strategy
{
    public class CalculateTaxAfter24Months : CalculateTaxStrategyBase
    {
        private const decimal taxRate = 0.15m;
        public decimal Calculate(decimal grossAmount)
        {
            return grossAmount * taxRate;
        }

        public bool Match(int termInMonths)
        {
            return termInMonths > 24;
        }
    }
}
