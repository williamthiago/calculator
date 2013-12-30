using Calculator.Core.Tests.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calculator.Core.Tests.Operation
{
    [TestClass]
    public class OperatorTests : CalculatorInitializeTests
    {
        [TestMethod]
        public void DontLoseValueWhenUseOperator()
        {
            var rightOperator = Calculator
                .AddDigit(Digit.One)
                .UseOperator(Operator.Addition)
                .CurrentValue();

            var leftOperator = Calculator.LeftValue(); // internal

            Assert.AreEqual(1m, leftOperator);
            Assert.AreEqual(0m, rightOperator);
        }

        [TestMethod]
        public void DontLoseValueWhenUseOperatorAndSetNewValue()
        {
            var rightOperator = Calculator
                .AddDigit(Digit.One)
                .UseOperator(Operator.Addition)
                .AddDigit(Digit.Two)
                .CurrentValue();

            var leftOperator = Calculator.LeftValue(); // internal

            Assert.AreEqual(1m, leftOperator);
            Assert.AreEqual(2m, rightOperator);
        }

        [TestMethod]
        public void CanUseOperatorOnInit()
        {
            var rightOperator = Calculator
                .UseOperator(Operator.Addition)
                .AddDigit(Digit.Two)
                .CurrentValue();
             
            var leftOperator = Calculator.LeftValue();
            
            Assert.AreEqual(0m, leftOperator);
            Assert.AreEqual(2m, rightOperator);
        }
    }
}
