using System;
using Calculator.Core.Tests.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calculator.Core.Tests.Operation
{
    [TestClass]
    public class DivisionDecimalTests : CalculatorInitializeTests
    {
        [TestMethod]
        public void CanDivideTwoDecimalValues()
        {
            Calculator
                .AddDigit(Digit.Three)
                .AddDecimal()
                .AddDigit(Digit.Three)
                .UseOperator(Operator.Division)
                .AddDigit(Digit.Two)
                .AddDecimal()
                .AddDigit(Digit.Two);


            Assert.AreEqual(1.5m, Calculator.Evaluate());
        }

        [TestMethod]
        public void CanDivideOneDecimalValueByAnotherValue()
        {
            Calculator
                .AddDigit(Digit.Three)
                .AddDecimal()
                .AddDigit(Digit.Three)
                .UseOperator(Operator.Division)
                .AddDigit(Digit.Four);

            Assert.AreEqual(0.825m, Calculator.Evaluate());
        }

        [TestMethod]
        public void CanDivideOneValueByAnotherDecimalValue()
        {
            Calculator
                .AddDigit(Digit.Six)
                .UseOperator(Operator.Division)
                .AddDigit(Digit.One)
                .AddDecimal()
                .AddDigit(Digit.Five);

            Assert.AreEqual(4m, Calculator.Evaluate());
        }

        [TestMethod]
        public void CanDivideTwoNegativeDecimalValues()
        {
            Calculator
                .AddDigit(Digit.Five)
                .AddDecimal()
                .AddDigit(Digit.Five)
                .Negate()
                .UseOperator(Operator.Division)
                .AddDigit(Digit.One)
                .AddDecimal()
                .AddDigit(Digit.One)
                .Negate();

            Assert.AreEqual(5m, Calculator.Evaluate());
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void CannotDivideByZero()
        {
            Calculator
                .AddDigit(Digit.Nine)
                .AddDecimal()
                .AddDigit(Digit.Seven)
                .UseOperator(Operator.Division)
                .AddDigit(Digit.Zero)
                .Evaluate();
        }
    }
}
