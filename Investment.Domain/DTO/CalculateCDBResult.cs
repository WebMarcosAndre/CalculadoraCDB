namespace Investment.Domain.DTO
{
    public class CalculateCDBResult
    {
        public decimal GrossAmount { get; }
        public decimal NetAmount { get; }

        public CalculateCDBResult(decimal grossAmount, decimal netAmount)
        {
            GrossAmount = grossAmount;
            NetAmount = netAmount;
        }
    }
}
