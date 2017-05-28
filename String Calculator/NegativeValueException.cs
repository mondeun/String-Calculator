using System;
using System.Collections.Generic;
using System.Linq;

namespace String_Calculator
{
    public class NegativeValueException : Exception
    {
        private string _message = "Negatives not allowed";

        public NegativeValueException(List<int> values)
        {
            values.ForEach(x => _message += $" {x}");
        }

        public override string Message => _message;
    }
}
