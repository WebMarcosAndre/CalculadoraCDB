using Investment.API.Models;
using Investment.Domain.CalculateTaxStrategy;
using Investment.Domain.DTO;
using Investment.Domain.Interface;

namespace Investment.Domain.Service
{
    public class CalculateCDBService : ICalculateCDBService
    {
        private const decimal CDI = 0.009m;
        private const decimal TB = 1.08m;

        private readonly ICalculateTaxStrategyService _calculateTaxStrategy;

        public CalculateCDBService(ICalculateTaxStrategyService calculateTaxService)
        {
            _calculateTaxStrategy = calculateTaxService;
        }

        public CalculateCDBResult CalculateInvestment(CalculateCDBInput input)
        {

            var grossAmount = CalculateGrossAmount(input);
            var netAmount = CalculateNetAmount(grossAmount, input.TermInMonths);

            return new CalculateCDBResult(grossAmount, netAmount);

        }

        public decimal CalculateGrossAmount(CalculateCDBInput input)
        {
            decimal finalValue = input.InitialAmount;

            for (int i = 0; i < input.TermInMonths; i++)
            {
                finalValue *= 1 + CDI * TB;
            }

            return finalValue;
        }

        public decimal CalculateNetAmount(decimal grossAmount, int termInMonths)
        {
            var tax = _calculateTaxStrategy.GetTax(grossAmount, termInMonths);

            var netAmount = grossAmount - tax;

            return netAmount;
        }
    }
}
