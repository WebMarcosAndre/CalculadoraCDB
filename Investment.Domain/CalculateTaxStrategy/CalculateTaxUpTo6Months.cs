namespace Investment.Domain.CalculateTaxStrategy
{
    public class CalculateTaxUpTo6Months : CalculateTaxStrategyBase
    {
        private const decimal taxRate = 0.225m;
        public decimal Calculate(decimal grossAmount)
        {
            var tax = grossAmount * taxRate;
            return tax;
        }

        public bool Match(int termInMonths)
        {
            return termInMonths <= 6;
        }
    }
}
