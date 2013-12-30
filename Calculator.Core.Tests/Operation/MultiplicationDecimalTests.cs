using System;
using Calculator.Core.Tests.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calculator.Core.Tests.Operation
{
    [TestClass]
    public class MultiplicationDecimalTests : CalculatorInitializeTests
    {
        [TestMethod]
        public void CanMultiplyTwoDecimalValues()
        {
            Calculator
                .AddDigit(Digit.Three)
                .AddDecimal()
                .AddDigit(Digit.Three)
                .UseOperator(Operator.Multiplication)
                .AddDigit(Digit.Two)
                .AddDecimal()
                .AddDigit(Digit.Two);


            Assert.AreEqual(7.26m, Calculator.Evaluate());
        }

        [TestMethod]
        public void CanMultiplyOneDecimalValueForAnotherValue()
        {
            Calculator
                .AddDigit(Digit.Three)
                .AddDecimal()
                .AddDigit(Digit.Three)
                .UseOperator(Operator.Multiplication)
                .AddDigit(Digit.Four);

            Assert.AreEqual(13.2m, Calculator.Evaluate());
        }

        [TestMethod]
        public void CanMultiplyOneValueForAnotherDecimalValue()
        {
            Calculator
                .AddDigit(Digit.Three)
                .UseOperator(Operator.Multiplication)
                .AddDigit(Digit.Four)
                .AddDecimal()
                .AddDigit(Digit.Seven);

            Assert.AreEqual(14.1m, Calculator.Evaluate());
        }

        [TestMethod]
        public void CanMultiplyTwoNegativeDecimalValues()
        {
            Calculator
                .AddDigit(Digit.Five)
                .AddDecimal()
                .AddDigit(Digit.Five)
                .Negate()
                .UseOperator(Operator.Multiplication)
                .AddDigit(Digit.Six)
                .AddDecimal()
                .AddDigit(Digit.Six)
                .Negate();

            Assert.AreEqual(36.3m, Calculator.Evaluate());
        }

        [TestMethod]
        public void CanMultiplyForZero()
        {
            Calculator
                .AddDigit(Digit.Nine)
                .AddDecimal()
                .AddDigit(Digit.Seven)
                .UseOperator(Operator.Multiplication)
                .AddDigit(Digit.Zero);

            Assert.AreEqual(0m, Calculator.Evaluate());
        }
    }
}
