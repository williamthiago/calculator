using System;
using Calculator.Core.Tests.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calculator.Core.Tests.Operation
{
    [TestClass]
    public class SubtractionDecimalTests : CalculatorInitializeTests
    {
        [TestMethod]
        public void CanSubtractTwoDecimalValues()
        {
            Calculator
                .AddDigit(Digit.One)
                .AddDecimal()
                .AddDigit(Digit.Two)
                .UseOperator(Operator.Subtraction)
                .AddDigit(Digit.Three)
                .AddDecimal()
                .AddDigit(Digit.Four);

            Assert.AreEqual(-2.2m, Calculator.Evaluate());
        }

        [TestMethod]
        public void CanSubtractOneDecimalValueFromAnotherValue()
        {
            Calculator
                .AddDigit(Digit.One)
                .UseOperator(Operator.Subtraction)
                .AddDigit(Digit.Two)
                .AddDecimal()
                .AddDigit(Digit.Three);

            Assert.AreEqual(-1.3m, Calculator.Evaluate());
        }

        [TestMethod]
        public void CanSubtractOneValueFromAnotherDecimalValue()
        {
            Calculator
                .AddDigit(Digit.One)
                .AddDecimal()
                .AddDigit(Digit.Two)
                .UseOperator(Operator.Subtraction)
                .AddDigit(Digit.Three);

            Assert.AreEqual(-1.8m, Calculator.Evaluate());
        }
        
        [TestMethod]
        public void CanSubtractTwoNegativeDecimalValues()
        {
            Calculator
                .AddDigit(Digit.Two)
                .AddDecimal()
                .AddDigit(Digit.Two)
                .Negate()
                .UseOperator(Operator.Subtraction)
                .AddDigit(Digit.One)
                .AddDecimal()
                .AddDigit(Digit.One)
                .Negate();

            Assert.AreEqual(-1.1m, Calculator.Evaluate());
        }
        
        [TestMethod]
        public void CanSubtractZeroFromDecimal()
        {
            Calculator
                .AddDigit(Digit.Nine)
                .AddDecimal()
                .AddDigit(Digit.Nine)
                .UseOperator(Operator.Subtraction)
                .AddDigit(Digit.Zero);

            Assert.AreEqual(9.9m, Calculator.Evaluate());
        }
    }
}
