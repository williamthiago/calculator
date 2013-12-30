using Calculator.Core.Tests.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calculator.Core.Tests.Input
{
    [TestClass]
    public class NegateInputTests : CalculatorInitializeTests
    {
        [TestMethod]
        public void CanNegateNumber()
        {
            Calculator
                .AddDigit(Digit.One)
                .AddDigit(Digit.Two)
                .AddDigit(Digit.Three);

            Assert.AreEqual(123m, Calculator.CurrentValue());
            
            Calculator
                .Negate();
            
            Assert.AreEqual(-123m, Calculator.CurrentValue());
        }

        [TestMethod]
        public void CanCancelNegateFromNumber()
        {
            Calculator
                .AddDigit(Digit.One)
                .AddDigit(Digit.Two)
                .AddDigit(Digit.Three);
            
            Assert.AreEqual(123m, Calculator.CurrentValue());
            
            Calculator
                .Negate()
                .Negate();
            
            Assert.AreEqual(123m, Calculator.CurrentValue());
        }
    }
}