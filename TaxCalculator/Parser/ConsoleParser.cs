using TaxCalculator.Entities;
using TaxCalculator.Exceptions;

namespace TaxCalculator.Parser
{
    public class ConsoleParser : IParser
    {
        public Employee InputParse(string[] input)
        {
            int annualSalary;

            if (input.Length < 2)
            {
                throw new InsufficientTaxInputException("Insufficient Tax Input. Try with input's format: \"Full Name\" Annual_Salary");
            }
            else if (!int.TryParse(input[1], out annualSalary))
            {
                throw new InvalidTaxSalaryInputException("Incorrect Annual Salary Input. Try with input's format \"Full Name\" Annual_Salary");
            }

            return new Employee
            {
                FullName = input[0],
                AnnualSalary = annualSalary
            };
        }
    }
}