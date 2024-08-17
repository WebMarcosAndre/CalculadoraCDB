namespace Investment.Application.UseCases.RunCalculate
{
    public class RunCalculateResponse
    {
        public decimal NetAmount { get; }
        public decimal GrossAmount { get; }

        public RunCalculateResponse(decimal netAmount, decimal grossAmount)
        {
            NetAmount = netAmount;
            GrossAmount = grossAmount;
        }
    }
}
