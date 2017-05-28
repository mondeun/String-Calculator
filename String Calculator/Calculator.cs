using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace String_Calculator
{
    public class Calculator
    {
        private readonly List<char> _delimiters;

        public Calculator()
        {
            _delimiters = new List<char> { ',', '\n' };
        }

        public int Add(string numbers)
        {
            if (string.IsNullOrEmpty(numbers))
                return 0;

            AddCustomDelimiter(numbers);

            var numberList = numbers.Split(_delimiters.ToArray());

            var result = 0;
            var negatives = new List<int>();

            foreach (var value in numberList)
            {
                if (int.TryParse(value, out int number))
                {
                    if(number < 0)
                        negatives.Add(number);
                    result += number;
                }
            }

            if (negatives.Any())
                throw new NegativeValueException(negatives);

            return result;
        }

        private void AddCustomDelimiter(string seq)
        {
            if (Regex.IsMatch(seq, @"(\/\/)[\W]*"))
            {
                _delimiters.Add(seq[2]);
            }
        }
    }
}
