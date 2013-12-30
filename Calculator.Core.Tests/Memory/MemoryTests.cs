using System.Globalization;
using System.Linq;
using Calculator.Core.Tests.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calculator.Core.Tests.Memory
{
    [TestClass]
    public class MemoryTests : CalculatorInitializeTests
    {
        [TestMethod]
        public void CanAddValueToMemory()
        {
            var memory = Calculator
                .AddDigit(Digit.One)
                .AddDigit(Digit.Two)
                .MemoryAdd()
                .MemoryValue();

            Assert.AreEqual(12m, memory);
        }

        [TestMethod]
        public void CanAddNegativeValueToMemory()
        {
            var memory = Calculator
                .AddDigit(Digit.One)
                .AddDigit(Digit.Two)
                .Negate()
                .MemoryAdd()
                .MemoryValue();

            Assert.AreEqual(-12m, memory);
        }

        [TestMethod]
        public void CanClearMemory()
        {
            var memory = Calculator
                .AddDigit(Digit.One)
                .AddDigit(Digit.Two)
                .MemoryAdd()
                .MemoryClear()
                .MemoryValue();

            Assert.AreEqual(0m, memory);
        }

        [TestMethod]
        public void CanRestoreFromMemory()
        {
            var memoryValue = Calculator
                .AddDigit(Digit.One)
                .AddDigit(Digit.Two)
                .MemoryAdd()
                .MemoryValue();

            var memoryRestore = Calculator
                .MemoryRestore()
                .CurrentValue();

            Assert.AreEqual(memoryValue, memoryRestore);
        }

        [TestMethod]
        public void CanRestoreNegativeValueFromMemory()
        {
            var memoryValue = Calculator
                .AddDigit(Digit.One)
                .AddDigit(Digit.Two)
                .Negate()
                .MemoryAdd()
                .MemoryValue();

            var memoryRestore = Calculator
                .MemoryRestore()
                .CurrentValue();

            Assert.AreEqual(memoryValue, memoryRestore);
        }

        [TestMethod]
        public void ReplaceCurrentValueWhenRestoreMemory()
        {
            var currentValue = Calculator
                .AddDigit(Digit.One)
                .AddDigit(Digit.Two)
                .MemoryAdd()
                .Clear()
                .AddDigit(Digit.Five)
                .AddDigit(Digit.Five)
                .CurrentValue();

            Assert.AreEqual(55m, currentValue);
            
            var memoryRestore = Calculator
                .MemoryRestore()
                .CurrentValue();

            Assert.AreEqual(12m, memoryRestore);
        }

        [TestMethod]
        public void CanAddValueToMemoryRepeatedly()
        {
            var memory = Calculator
                .AddDigit(Digit.One)
                .MemoryAdd()
                .AddDigit(Digit.Two)
                .MemoryAdd()
                .AddDigit(Digit.Three)
                .MemoryAdd()
                .AddDigit(Digit.Four)
                .MemoryAdd()
                .AddDigit(Digit.Five)
                .MemoryAdd()
                .MemoryValue();

            Assert.AreEqual(15m, memory);
        }

        [TestMethod]
        public void InitWithMemoryEmpty()
        {
            Assert.AreEqual(false, Calculator.HasValueStoredInMemory());
        }

        [TestMethod]
        public void MemoryIsEmptyAfterMemoryClear()
        {
            Calculator
                .AddDigit(Digit.One)
                .MemoryAdd();

            Assert.AreEqual(true, Calculator.HasValueStoredInMemory());

            Calculator.MemoryClear();

            Assert.AreEqual(false, Calculator.HasValueStoredInMemory());
        }

        [TestMethod]
        public void MemoryIsEmptyIfMemoryValueIsZero()
        {
            Calculator
                .AddDigit(Digit.One)
                .MemoryAdd();

            Assert.AreEqual(true, Calculator.HasValueStoredInMemory());

            Calculator
                .AddDigit(Digit.One)
                .Negate()
                .MemoryAdd();
            
            Assert.AreEqual(false, Calculator.HasValueStoredInMemory());
        }

    }
}
