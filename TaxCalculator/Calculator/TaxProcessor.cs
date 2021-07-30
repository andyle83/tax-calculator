using TaxCalculator.Entities;

namespace TaxCalculator.Calculator
{
    public class TaxProcessor : ITaxProcessor
    {
        private IIncomeTaxStrategy _taxStrategy;

        public TaxProcessor(IIncomeTaxStrategy taxStrategy)
        {
            _taxStrategy = taxStrategy;
        }

        public TaxResult CalculateTaxFromSalary(int annualSalary)
        {
            return _taxStrategy.CalculateIncomeTax(annualSalary);
        }
    }
}