using System;
using Calculator.Core.Tests.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calculator.Core.Tests.Operation
{
    [TestClass]
    public class DivisionTests : CalculatorInitializeTests
    {
        [TestMethod]
        public void CanDivideTwoValues()
        {
            Calculator
                .AddDigit(Digit.Eight)
                .UseOperator(Operator.Division)
                .AddDigit(Digit.Two);

            Assert.AreEqual(4m, Calculator.Evaluate());
        }

        [TestMethod]
        public void CanDivideOneNegativeValueByAnotherValue()
        {
            Calculator
                .AddDigit(Digit.One)
                .AddDigit(Digit.Two)
                .UseOperator(Operator.Division)
                .AddDigit(Digit.Four)
                .Negate();
            
            Assert.AreEqual(-3m, Calculator.Evaluate());
        }

        [TestMethod]
        public void CanDivideOneValueByAnotherNegativeValue()
        {
            Calculator
                .AddDigit(Digit.One)
                .AddDigit(Digit.Two)
                .Negate()
                .UseOperator(Operator.Division)
                .AddDigit(Digit.Four);

            Assert.AreEqual(-3m, Calculator.Evaluate());
        }

        [TestMethod]
        public void CanDivideTwoNegativeValues()
        {
            Calculator
                .AddDigit(Digit.One)
                .AddDigit(Digit.Two)
                .Negate()
                .UseOperator(Operator.Division)
                .AddDigit(Digit.Three)
                .Negate();

            Assert.AreEqual(4m, Calculator.Evaluate());
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void CannotDivideByZero()
        {
            Calculator
                .AddDigit(Digit.Two)
                .UseOperator(Operator.Division)
                .AddDigit(Digit.Zero)
                .Evaluate();

        }
    }
}
