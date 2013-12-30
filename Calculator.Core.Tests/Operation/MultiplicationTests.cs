using System;
using Calculator.Core.Tests.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calculator.Core.Tests.Operation
{
    [TestClass]
    public class MultiplicationTests : CalculatorInitializeTests
    {
        [TestMethod]
        public void CanMultiplyTwoValues()
        {
            Calculator
                .AddDigit(Digit.One)
                .UseOperator(Operator.Multiplication)
                .AddDigit(Digit.Two);

            Assert.AreEqual(2m, Calculator.Evaluate());
        }

        [TestMethod]
        public void CanMultiplyOneNegativeValueForAnotherValue()
        {
            Calculator
                .AddDigit(Digit.Three)
                .UseOperator(Operator.Multiplication)
                .AddDigit(Digit.Four)
                .Negate();
            
            Assert.AreEqual(-12m, Calculator.Evaluate());
        }

        [TestMethod]
        public void CanMultiplyOneValueForAnotherNegativeValue()
        {
            Calculator
                .AddDigit(Digit.Three)
                .Negate()
                .UseOperator(Operator.Multiplication)
                .AddDigit(Digit.Four);

            Assert.AreEqual(-12m, Calculator.Evaluate());
        }

        [TestMethod]
        public void CanMultiplyTwoNegativeValues()
        {
            Calculator
                .AddDigit(Digit.Five)
                .Negate()
                .UseOperator(Operator.Multiplication)
                .AddDigit(Digit.Six)
                .Negate();

            Assert.AreEqual(30m, Calculator.Evaluate());
        }

        [TestMethod]
        public void CanMultiplyForZero()
        {
            Calculator
                .AddDigit(Digit.Nine)
                .UseOperator(Operator.Multiplication)
                .AddDigit(Digit.Zero);

            Assert.AreEqual(0m, Calculator.Evaluate());
        }
    }
}
