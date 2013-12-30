using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Calculator.Core
{
    public class Calculator
    {
        #region Const

        internal const int MaxDigits = 18;
        internal const string DecimalOperator = ".";
        internal const string MinusOperator = "-";

        #endregion Const

        #region Ctor

        public Calculator()
        {
            Clear();
        }

        #endregion Ctor

        #region Private

        private readonly Stack<string> _digits = new Stack<string>();
        private decimal? _leftOperand;
        private decimal? _memory;
        private Operator _currentOperator;
        private bool _negate;

        #endregion Private

        #region Operation Methods

        public Calculator AddDecimal()
        {
            if (_digits.Count < MaxDigits - 1 && !_digits.Contains(DecimalOperator)) // need space to mantissa
            {
                _digits.Push(DecimalOperator);
            }

            return this;
        }

        public Calculator AddDigit(Digit digit)
        {
            if (_digits.Count < MaxDigits)
            {
                switch (digit) // prevent input
                {
                    case Digit.Zero:
                    case Digit.One:
                    case Digit.Two:
                    case Digit.Three:
                    case Digit.Four:
                    case Digit.Five:
                    case Digit.Six:
                    case Digit.Seven:
                    case Digit.Eight:
                    case Digit.Nine:
                        _digits.Push(((int) digit).ToString());
                        break;
                }
            }

            return this;
        }

        public Calculator Backspace()
        {
            if (_digits.Any())
            {
                _digits.Pop();
            }

            return this;
        }

        public Calculator Negate()
        {
            _negate = !_negate;

            return this;
        }

        public Calculator UseOperator(Operator value)
        {
            _currentOperator = value;

            _leftOperand = CurrentValue();

            _digits.Clear();

            _negate = false;

            return this;
        }

        public Calculator MemoryAdd()
        {
            var value = CurrentValue();

            _memory = _memory.GetValueOrDefault() + value;

            if (_memory.GetValueOrDefault() == 0)
                MemoryClear();

            _digits.Clear();
            _negate = false;

            return this;
        }

        public Calculator MemoryRestore()
        {
            _digits.Clear();

            var value = _memory
                .GetValueOrDefault()
                .ToString();

            foreach (var digit in value.ToCharArray())
            {
                var digitValue = -1;
                if (int.TryParse(digit.ToString(), out digitValue))
                {
                    AddDigit((Digit)digitValue);
                }
            }

            _negate = value.StartsWith(MinusOperator);

            return this;
        }

        public bool HasValueStoredInMemory()
        {
            return _memory.HasValue;
        }

        public Calculator MemoryClear()
        {
            _memory = null;
            
            return this;
        }

        public Calculator Clear()
        {
            _currentOperator = Operator.None;
            _leftOperand = null;
            _digits.Clear();
            _negate = false;

            return this;
        }

        #endregion Operation Methods

        #region Result Methods

        internal decimal MemoryValue()
        {
            return _memory.GetValueOrDefault();
        }

        internal decimal LeftValue()
        {
            return _leftOperand.GetValueOrDefault();
        }

        public decimal CurrentValue()
        {
            if (!_digits.Any())
            {
                return 0;
            }

            string valueString = string.Empty;

            var stack = new Stack<string>(_digits);

            while (stack.Any())
            {
                string digit = stack.Pop();

                valueString += digit;
            }

            if (valueString.EndsWith("."))
            {
                valueString += "0";
            }

            return _negate ? 
                -decimal.Parse(valueString, CultureInfo.InvariantCulture) : 
                decimal.Parse(valueString, CultureInfo.InvariantCulture);
        }

        public decimal Evaluate()
        {
            decimal value = CurrentValue();

            if (_leftOperand.HasValue)
            {
                switch (_currentOperator)
                {
                    case Operator.Addition:
                        value = _leftOperand.GetValueOrDefault() + value;
                        break;
                    case Operator.Subtraction:
                        value = _leftOperand.GetValueOrDefault() - value;
                        break;
                    case Operator.Multiplication:
                        value = _leftOperand.GetValueOrDefault()*value;
                        break;
                    case Operator.Division:
                        value = _leftOperand.GetValueOrDefault()/value;
                        break;
                }

                Clear();
            }

            return value;
        }

        #endregion Result Methods
    }
}
