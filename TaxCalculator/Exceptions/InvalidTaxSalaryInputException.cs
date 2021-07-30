using System;

namespace TaxCalculator.Exceptions
{
    public class InvalidTaxSalaryInputException : Exception
    {
        public InvalidTaxSalaryInputException()
        {
        }

        public InvalidTaxSalaryInputException(string message)
            : base(message)
        {
        }

        public InvalidTaxSalaryInputException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}