using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calculator.Core.Tests.Base
{
    [TestClass]
    public class CalculatorInitializeTests
    {
        protected Calculator Calculator;

        [TestInitialize]
        public void Init()
        {
            Calculator = new Calculator();
        }
    }
}