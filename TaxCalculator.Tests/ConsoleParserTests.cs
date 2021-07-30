using NUnit.Framework;
using TaxCalculator.Exceptions;
using TaxCalculator.Parser;

namespace TaxCalculator.Tests
{
    [TestFixture]
    public class ConsoleParserTests
    {
        private IParser _inputParser;

        [SetUp]
        public void Setup()
        {
            _inputParser = new ConsoleParser();
        }

        [TestCase(new object[] { "Mary Song", "6000" })]
        public void GivenValidInput_ExtractEmployeeInfo(params string[] consoleInput)
        {
            var result = _inputParser.InputParse(consoleInput);

            Assert.That(result.FullName, Is.EqualTo("Mary Song"));
            Assert.That(result.AnnualSalary, Is.EqualTo(6000));
        }

        [TestCase(new object[] { "Mary Song", "NotANumber" })]
        public void GivenInvalidSalaryInput_ThrowsException(params string[] consoleInput)
        {
            Assert.Throws<InvalidTaxSalaryInputException>(() => _inputParser.InputParse(consoleInput));
        }

        [TestCase(new object[] { "Mary Song" })]
        public void GivenInsufficientInput_ThrowsException(params string[] consoleInput)
        {
            Assert.Throws<InsufficientTaxInputException>(() => _inputParser.InputParse(consoleInput));
        }
    }
}