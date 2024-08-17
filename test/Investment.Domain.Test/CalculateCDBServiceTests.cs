using Investment.API.Models;
using Investment.Domain.CalculateTaxStrategy;
using Investment.Domain.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace Investment.Domain.Tests
{
    [TestClass]
    public class CalculateCDBServiceTests
    {
        private Mock<ICalculateTaxStrategyService> _mockTaxStrategy;
        private CalculateCDBService _calculateCDBService;

        [TestInitialize]
        public void Setup()
        {
            _mockTaxStrategy = new Mock<ICalculateTaxStrategyService>();
            _calculateCDBService = new CalculateCDBService(_mockTaxStrategy.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        [DataRow(1000.0, 0)]
        [DataRow(-1000.0, 1)]
        public void CalculateInvestment_Input_ThrowsException(double initialAmountDouble, int termInMonths)
        {
            //Arrange                 
            decimal initialAmount = (decimal)initialAmountDouble;
            new CalculateCDBInput(initialAmount, termInMonths);
        }

        [TestMethod]
        public void CalculateInvestment_ValidParameters_ReturnsExpectedResult()
        {
            // Arrange
            var input = new CalculateCDBInput(
                initialAmount: 1000m,
                termInMonths: 12);

            decimal taxExpected = 100m;

            decimal expectedGrossAmount = _calculateCDBService.CalculateGrossAmount(input);
            decimal expectedNetAmount = expectedGrossAmount - taxExpected;

            _mockTaxStrategy.Setup(x =>
                x.GetTax(
                    It.IsAny<decimal>(),
                    It.IsAny<int>())
            ).Returns(taxExpected);

            // Act
            var result = _calculateCDBService.CalculateInvestment(input);

            // Assert
            Assert.AreEqual(expectedGrossAmount, result.GrossAmount);
            Assert.AreEqual(expectedNetAmount, result.NetAmount);
        }

        [TestMethod]
        public void CalculateGrossAmount_CorrectCalculation_ReturnsExpectedValue()
        {
            // Arrange
            var input = new CalculateCDBInput(
                initialAmount: 1000m,
                termInMonths: 12);

            decimal expectedValue = 1123.08m;

            // Act
            var result = _calculateCDBService.CalculateGrossAmount(input);

            // Assert
            Assert.AreEqual(expectedValue, result, 0.01m);
        }

        [TestMethod]
        public void CalculateNetAmount_CorrectCalculation_ReturnsExpectedValue()
        {
            // Arrange
            decimal grossAmount = 1200m;
            int termInMonth = 12;
            decimal expectedTax = 100m;
            decimal expectedNetAmount = grossAmount - expectedTax;

            _mockTaxStrategy.Setup(x => x.GetTax(grossAmount, termInMonth)).Returns(expectedTax);

            // Act
            var result = _calculateCDBService.CalculateNetAmount(grossAmount, termInMonth);

            // Assert
            Assert.AreEqual(expectedNetAmount, result);
        }
    }
}
