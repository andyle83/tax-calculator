using TaxCalculator.Entities;

namespace TaxCalculator.Calculator
{
    public interface ITaxProcessor
    {
        public TaxResult CalculateTaxFromSalary(int annualSalary);
    }
}