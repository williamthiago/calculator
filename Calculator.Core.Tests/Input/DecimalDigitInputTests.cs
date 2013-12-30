using System.Globalization;
using System.Linq;
using Calculator.Core.Tests.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calculator.Core.Tests.Input
{
    [TestClass]
    public class DecimalDigitInputTests : CalculatorInitializeTests
    {
        [TestMethod]
        public void CanAddDecimal()
        {
            Calculator
                .AddDigit(Digit.One)
                .AddDecimal()
                .AddDigit(Digit.Two);

            Assert.AreEqual(1.2m, Calculator.CurrentValue());
        }

        [TestMethod]
        public void IgnoreIfAddManyDecimal()
        {
            Calculator
                .AddDigit(Digit.One)
                .AddDecimal()
                .AddDigit(Digit.Two)
                .AddDecimal()
                .AddDigit(Digit.Three);
            
            Assert.AreEqual(1.23m, Calculator.CurrentValue());
        }

        [TestMethod]
        public void CanAddDecimalWithZeroInIntegerPart()
        {
            Calculator
                .AddDigit(Digit.Zero)
                .AddDecimal()
                .AddDigit(Digit.One);
            
            Assert.AreEqual(0.1m, Calculator.CurrentValue());
        }

        [TestMethod]
        public void NotIgnoreZeroInMantissa()
        {
            Calculator
                .AddDigit(Digit.One)
                .AddDecimal()
                .AddDigit(Digit.Zero)
                .AddDigit(Digit.Zero)
                .AddDigit(Digit.One);
            
            Assert.AreEqual(1.001m, Calculator.CurrentValue());
        }

        [TestMethod]
        public void CannotAddMantissaIfMaxDigitsAchieved()
        {
            // 111111111
            // 1111111.0
            // 11111111
            var expected = decimal.Parse(string.Join("", Enumerable.Repeat("1", Calculator.MaxDigits)), CultureInfo.InvariantCulture);
            for (int i = 0; i < Calculator.MaxDigits - 1; i++)
            {
                Calculator.AddDigit(Digit.One);
            }

            Calculator
                .AddDecimal()
                .AddDigit(Digit.One);
            
            Assert.AreEqual(expected, Calculator.CurrentValue());
        }

        [TestMethod]
        public void CanAddMantissaIfMaxDigitsNotAchieved()
        {
            // 111111111
            // 1111111.0
            // 11111111
            var expected = decimal.Parse(string.Join("", Enumerable.Repeat("1", Calculator.MaxDigits - 2)) + ".9", CultureInfo.InvariantCulture);
            for (int i = 0; i < Calculator.MaxDigits - 2; i++)
            {
                Calculator.AddDigit(Digit.One);
            }
            Calculator
                .AddDecimal()
                .AddDigit(Digit.Nine);

            Assert.AreEqual(expected, Calculator.CurrentValue());
        }

    }
}
