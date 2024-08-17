using MediatR;

namespace Investment.Application.UseCases.RunCalculate
{
    public class RunCalculateCommand : IRequest<RunCalculateResponse>
    {
        public int DurationInMonth { get; }
        public decimal Amount { get; }

        public RunCalculateCommand(int durationInMonth, decimal amount)
        {
            DurationInMonth = durationInMonth;
            Amount = amount;
        }
    }
}
