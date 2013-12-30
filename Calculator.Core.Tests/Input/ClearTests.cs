using Calculator.Core.Tests.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calculator.Core.Tests.Input
{
    [TestClass]
    public class ClearTests : CalculatorInitializeTests
    {
        [TestMethod]
        public void InitialCurrentValueIsZero()
        {
            Assert.AreEqual(0m, Calculator.CurrentValue());
        }

        [TestMethod]
        public void CurrentValueIsZeroAfterClear()
        {
            Calculator.AddDigit(Digit.One);
            Assert.AreEqual(1m, Calculator.CurrentValue());
            
            Calculator.Clear();
            Assert.AreEqual(0m, Calculator.CurrentValue());
        }
    }
}