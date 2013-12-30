using Calculator.Core.Tests.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calculator.Core.Tests.Input
{
    [TestClass]
    public class RemoveInputTests : CalculatorInitializeTests
    {
        [TestMethod]
        public void CanRemoveDigits()
        {
            Calculator
                .AddDigit(Digit.One)
                .AddDigit(Digit.Two);

            Assert.AreEqual(12m, Calculator.CurrentValue());
            
            Calculator
                .Backspace();

            Assert.AreEqual(1m, Calculator.CurrentValue());
        }

        [TestMethod]
        public void CanRemoveDigitsFromMantissa()
        {
            Calculator
                .AddDigit(Digit.One)
                .AddDecimal()
                .AddDigit(Digit.Two)
                .AddDigit(Digit.Three)
                .AddDigit(Digit.Four);
            
            Assert.AreEqual(1.234m, Calculator.CurrentValue());
            
            Calculator
                .Backspace()
                .Backspace();
            
            Assert.AreEqual(1.2m, Calculator.CurrentValue());
        }

        [TestMethod]
        public void CanRemoveDecimal()
        {
            Calculator
                .AddDigit(Digit.One)
                .AddDecimal()
                .AddDigit(Digit.Two)
                .AddDigit(Digit.Three)
                .AddDigit(Digit.Four);

            Assert.AreEqual(1.234m, Calculator.CurrentValue());

            Calculator
                .Backspace()
                .Backspace()
                .Backspace()
                .Backspace()
                .AddDigit(Digit.Five);

            Assert.AreEqual(15m, Calculator.CurrentValue());
        }
    }
}