namespace Investment.Domain.CalculateTaxStrategy
{
    public interface ICalculateTaxStrategyService
    {
        decimal GetTax(decimal grossAmount, int termInMonths);
    }
}
