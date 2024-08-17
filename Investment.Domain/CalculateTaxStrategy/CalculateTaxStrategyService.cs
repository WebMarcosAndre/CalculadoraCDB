using Investment.Domain.Message;
using System;
using System.Collections.Generic;

namespace Investment.Domain.CalculateTaxStrategy
{
    public class CalculateTaxStrategyService : ICalculateTaxStrategyService
    {
        private readonly IEnumerable<CalculateTaxStrategyBase> _calculateTaxStrategies;

        public CalculateTaxStrategyService(IEnumerable<CalculateTaxStrategyBase> calculateTaxStrategies)
        {
            _calculateTaxStrategies = calculateTaxStrategies;
        }

        public decimal GetTax(decimal grossAmount, int termInMonths)
        {
            foreach (var strategy in _calculateTaxStrategies)
            {
                if (strategy.Match(termInMonths))
                {
                    var tax = strategy.Calculate(grossAmount);

                    return tax;
                }
            }

            throw new InvalidOperationException(ValidationMessage.InvalidInput);
        }
    }
}
