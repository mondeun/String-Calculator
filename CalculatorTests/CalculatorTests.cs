using NUnit.Framework;
using String_Calculator;

namespace CalculatorTests
{
    [TestFixture]
    public class CalculatorTests
    {
        private Calculator _sut;

        [SetUp]
        public void Setup()
        {
            _sut = new Calculator();
        }

        [Test]
        public void EmptyStringReturnsZero()
        {
            var result = _sut.Add("");

            Assert.AreEqual(0, result);
        }

        [Test]
        [TestCase("1", 1)]
        [TestCase("2,3", 5)]
        [TestCase("3,3,4", 10)]
        public void AddsAllValuesTogether(string numbers, int expected)
        {
            var result = _sut.Add(numbers);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void AddsCanHandleMultiDigitNumbers()
        {
            var result = _sut.Add("10,7,3");

            Assert.AreEqual(20, result);
        }

        [Test]
        public void AddAcceptsNewLineAsDelimiter()
        {
            var result = _sut.Add("2\n4");

            Assert.AreEqual(6, result);
        }

        [Test]
        public void AddSkipsDelimitersInARow()
        {
            var result = _sut.Add("2,\n");

            Assert.AreEqual(2, result);
        }

        [Test]
        [TestCase("//;\n1,2;3", 6)]
        [TestCase("//?\n10?5", 15)]
        public void AddHandlesCustomDelimiters(string numbers, int expected)
        {
            var result = _sut.Add(numbers);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void AddNegativeNumberThrowsException()
        {
            var e = Assert.Throws<NegativeValueException>(() =>
                _sut.Add("-1,-3")
            );
            Assert.AreEqual("Negatives not allowed -1 -3", e.Message);
        }
    }
}
