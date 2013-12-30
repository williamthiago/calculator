using System;
using Calculator.Core.Tests.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calculator.Core.Tests.Operation
{
    [TestClass]
    public class SubtractionTests : CalculatorInitializeTests
    {
        [TestMethod]
        public void CanSubtractTwoValues()
        {
            Calculator
                .AddDigit(Digit.One)
                .UseOperator(Operator.Subtraction)
                .AddDigit(Digit.Two);

            Assert.AreEqual(-1m, Calculator.Evaluate());
        }

        [TestMethod]
        public void CanSubtractOneNegativeValueFromAnotherValue()
        {
            Calculator
                .AddDigit(Digit.Three)
                .UseOperator(Operator.Subtraction)
                .AddDigit(Digit.Four)
                .Negate();
            
            Assert.AreEqual(7m, Calculator.Evaluate());
        }

        [TestMethod]
        public void CanSubtractOneValueFromAnotherNegativeValue()
        {
            Calculator
                .AddDigit(Digit.Three)
                .Negate()
                .UseOperator(Operator.Subtraction)
                .AddDigit(Digit.Four);

            Assert.AreEqual(-7m, Calculator.Evaluate());
        }

        [TestMethod]
        public void CanSubtractTwoNegativeValues()
        {
            Calculator
                .AddDigit(Digit.Five)
                .Negate()
                .UseOperator(Operator.Subtraction)
                .AddDigit(Digit.Six)
                .Negate();

            Assert.AreEqual(1m, Calculator.Evaluate());
        }

        [TestMethod]
        public void CanSubtractZero()
        {
            Calculator
                .AddDigit(Digit.Nine)
                .UseOperator(Operator.Subtraction)
                .AddDigit(Digit.Zero);

            Assert.AreEqual(9m, Calculator.Evaluate());
        }
    }
}
