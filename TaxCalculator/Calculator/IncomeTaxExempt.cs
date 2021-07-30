using TaxCalculator.Entities;

namespace TaxCalculator.Calculator
{
    public class IncomeTaxExempt : IIncomeTaxStrategy

    {
        public TaxResult CalculateIncomeTax(int annualSalary)
        {
            return new TaxResult()
            {
                GrossMonthlyIncome = annualSalary / 12,
                MonthlyIncomeTax = 0,
                NetMonthlyIncome = annualSalary / 12
            };
        }
    }
}