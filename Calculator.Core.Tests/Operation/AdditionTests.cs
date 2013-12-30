using System;
using Calculator.Core.Tests.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calculator.Core.Tests.Operation
{
    [TestClass]
    public class AdditionTests : CalculatorInitializeTests
    {
        [TestMethod]
        public void CanAddTwoValues()
        {
            Calculator
                .AddDigit(Digit.One)
                .UseOperator(Operator.Addition)
                .AddDigit(Digit.Two);

            Assert.AreEqual(3m, Calculator.Evaluate());
        }

        [TestMethod]
        public void CanAddOneNegativeValueToAnotherValue()
        {
            Calculator
                .AddDigit(Digit.Three)
                .UseOperator(Operator.Addition)
                .AddDigit(Digit.Four)
                .Negate();
            
            Assert.AreEqual(-1m, Calculator.Evaluate());
        }

        [TestMethod]
        public void CanAddOneValueToAnotherNegativeValue()
        {
            Calculator
                .AddDigit(Digit.Three)
                .Negate()
                .UseOperator(Operator.Addition)
                .AddDigit(Digit.Four);

            Assert.AreEqual(1m, Calculator.Evaluate());
        }

        [TestMethod]
        public void CanAddTwoNegativeValues()
        {
            Calculator
                .AddDigit(Digit.Five)
                .Negate()
                .UseOperator(Operator.Addition)
                .AddDigit(Digit.Six)
                .Negate();

            Assert.AreEqual(-11m, Calculator.Evaluate());
        }

        [TestMethod]
        public void CanAddZero()
        {
            Calculator
                .AddDigit(Digit.Nine)
                .UseOperator(Operator.Addition)
                .AddDigit(Digit.Zero);

            Assert.AreEqual(9m, Calculator.Evaluate());
        }
    }
}
