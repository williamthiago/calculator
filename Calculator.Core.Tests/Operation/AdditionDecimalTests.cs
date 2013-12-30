using System;
using Calculator.Core.Tests.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calculator.Core.Tests.Operation
{
    [TestClass]
    public class AdditionDecimalTests : CalculatorInitializeTests
    {
        [TestMethod]
        public void CanAddTwoDecimalValues()
        {
            Calculator
                .AddDigit(Digit.One)
                .AddDecimal()
                .AddDigit(Digit.Two)
                .UseOperator(Operator.Addition)
                .AddDigit(Digit.Three)
                .AddDecimal()
                .AddDigit(Digit.Four);

            Assert.AreEqual(4.6m, Calculator.Evaluate());
        }

        [TestMethod]
        public void CanAddOneDecimalValueToAnotherValue()
        {
            Calculator
                .AddDigit(Digit.One)
                .UseOperator(Operator.Addition)
                .AddDigit(Digit.Two)
                .AddDecimal()
                .AddDigit(Digit.Three);

            Assert.AreEqual(3.3m, Calculator.Evaluate());
        }

        [TestMethod]
        public void CanAddOneValueToAnotherDecimalValue()
        {
            Calculator
                .AddDigit(Digit.One)
                .AddDecimal()
                .AddDigit(Digit.Two)
                .UseOperator(Operator.Addition)
                .AddDigit(Digit.Three);

            Assert.AreEqual(4.2m, Calculator.Evaluate());
        }
        
        [TestMethod]
        public void CanAddTwoNegativeDecimalValues()
        {
            Calculator
                .AddDigit(Digit.Two)
                .AddDecimal()
                .AddDigit(Digit.Two)
                .Negate()
                .UseOperator(Operator.Addition)
                .AddDigit(Digit.One)
                .AddDecimal()
                .AddDigit(Digit.One)
                .Negate();

            Assert.AreEqual(-3.3m, Calculator.Evaluate());
        }
        
        [TestMethod]
        public void CanAddZeroToDecimal()
        {
            Calculator
                .AddDigit(Digit.Nine)
                .AddDecimal()
                .AddDigit(Digit.Nine)
                .UseOperator(Operator.Addition)
                .AddDigit(Digit.Zero);

            Assert.AreEqual(9.9m, Calculator.Evaluate());
        }
    }
}
