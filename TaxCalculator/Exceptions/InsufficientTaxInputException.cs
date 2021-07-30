using System;

namespace TaxCalculator.Exceptions
{
    public class InsufficientTaxInputException : Exception
    {
        public InsufficientTaxInputException()
        {
        }

        public InsufficientTaxInputException(string message)
            : base(message)
        {
        }

        public InsufficientTaxInputException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}