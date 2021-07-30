using TaxCalculator.Entities;

namespace TaxCalculator.Calculator
{
    public interface IIncomeTaxStrategy
    {
        public TaxResult CalculateIncomeTax(int annualSalary);
    }
}