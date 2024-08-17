using Investment.Domain.CalculateTaxStrategy;
using Investment.Domain.Strategy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;

namespace Investment.Tests.CalculateTaxStrategy
{
    [TestClass]
    public class CalculateTaxStrategyTests
    {
        [TestMethod]
        [DataRow(100.0, 1, 22.5)]   // UpTo 6 months
        [DataRow(100.0, 7, 20.0)]   // Between 7 and 12 months
        [DataRow(100.0, 13, 17.5)]  // Between 13 and 24 months
        [DataRow(100.0, 25, 15.0)]  // After 24 months
        public void GetTax_ShouldReturnCorrectTax(double grossAmountDouble,
                                                    int termInMonth,
                                                    double taxExpectedDouble)
        {
            // Arrange   
            decimal grossAmount = (decimal)grossAmountDouble;
            decimal taxExpected = (decimal)taxExpectedDouble;

            var strategies = new List<CalculateTaxStrategyBase>
            {
                new CalculateTaxUpTo6Months(),
                new CalculateTaxUpTo12Months(),
                new CalculateTaxUpTo24Months(),
                new CalculateTaxAfter24Months(),
            };

            var calculateTaxStrategy = new CalculateTaxStrategyService(strategies);

            // Act
            var tax = calculateTaxStrategy.GetTax(grossAmount, termInMonth);

            // Assert
            Assert.AreEqual(taxExpected, tax);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void GetTax_ShouldThrowInvalidOperationException_WhenNoStrategyMatches()
        {
            // Arrange
            var grossAmount = 1000m;
            var termInMonths = 12;

            var nonMatch = new Mock<CalculateTaxStrategyBase>();
            nonMatch.Setup(s => s.Match(termInMonths)).Returns(false);

            var strategies = new List<CalculateTaxStrategyBase>
            {
                nonMatch.Object
            };

            var calculateTaxStrategy = new CalculateTaxStrategyService(strategies);

            // Act
            calculateTaxStrategy.GetTax(grossAmount, termInMonths);
        }
    }
}
