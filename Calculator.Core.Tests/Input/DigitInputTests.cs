using System.Globalization;
using System.Linq;
using Calculator.Core.Tests.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calculator.Core.Tests.Input
{
    [TestClass]
    public class DigitInputTests : CalculatorInitializeTests
    {
        [TestMethod]
        public void CanAddOneDigit()
        {
            Calculator
                .AddDigit(Digit.One);
            
            Assert.AreEqual(1m, Calculator.CurrentValue());
        }

        [TestMethod]
        public void CanAddManyDigits()
        {
            Calculator
                .AddDigit(Digit.One)
                .AddDigit(Digit.Zero)
                .AddDigit(Digit.Five);

            Assert.AreEqual(105m, Calculator.CurrentValue());
        }

        [TestMethod]
        public void AllDigitsAreValid()
        {
            Calculator
                .AddDigit(Digit.One)
                .AddDigit(Digit.Two)
                .AddDigit(Digit.Three)
                .AddDigit(Digit.Four)
                .AddDigit(Digit.Five)
                .AddDigit(Digit.Six)
                .AddDigit(Digit.Seven)
                .AddDigit(Digit.Eight)
                .AddDigit(Digit.Nine);

            Assert.AreEqual(123456789m, Calculator.CurrentValue());
        }

        [TestMethod]
        public void IgnoreLeadZero()
        {
            Calculator
                .AddDigit(Digit.Zero)
                .AddDigit(Digit.Zero)
                .AddDigit(Digit.Zero)
                .AddDigit(Digit.Zero)
                .AddDigit(Digit.One);
            
            Assert.AreEqual(1m, Calculator.CurrentValue());
        }

        [TestMethod]
        public void CanAddDigitsUntilMax()
        {
            var expected = decimal.Parse(string.Join("", Enumerable.Repeat("1", Calculator.MaxDigits)), CultureInfo.InvariantCulture);
            for (int i = 0; i < Calculator.MaxDigits; i++)
            {
                Calculator.AddDigit(Digit.One);
            }
            
            Assert.AreEqual(expected, Calculator.CurrentValue());
        }

        [TestMethod]
        public void IgnoreDigitsAfterMax()
        {
            var expected = decimal.Parse(string.Join("", Enumerable.Repeat("1", Calculator.MaxDigits)), CultureInfo.InvariantCulture);
            for (int i = 0; i < Calculator.MaxDigits + 10; i++)
            {
                Calculator.AddDigit(Digit.One);
            }

            Assert.AreEqual(expected, Calculator.CurrentValue());
        }
    }
}