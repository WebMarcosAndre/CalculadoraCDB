namespace Investment.Domain.CalculateTaxStrategy
{
    public interface CalculateTaxStrategyBase
    {
        bool Match(int termInMonths);
        decimal Calculate(decimal grossAmount);
    }
}
