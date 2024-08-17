using Investment.Domain.Message;
using System;

namespace Investment.API.Models
{
    public class CalculateCDBInput
    {
        public int TermInMonths { get; }

        public decimal InitialAmount { get; }

        public CalculateCDBInput(decimal initialAmount, int termInMonths)
        {
            if (termInMonths == 0)
            {
                throw new InvalidOperationException(ValidationMessage.TermInMonthGreaterThanZero);
            }

            if (initialAmount < 0)
            {
                throw new InvalidOperationException(ValidationMessage.AmountCannotBeNegative);
            }

            InitialAmount = initialAmount;
            TermInMonths = termInMonths;
        }
    }
}