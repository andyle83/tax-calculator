using TaxCalculator.Entities;

namespace TaxCalculator.Calculator
{
    public class IncomeTaxFirstRage : IIncomeTaxStrategy
    {
        public TaxResult CalculateIncomeTax(int annualSalary)
        {
            var taxRules = TaxRangeSettings.GetTaxRangeRules()[TaxRangeType.FIRST_RANGE];

            double grossMonthlyIncome = annualSalary / 12;
            double monthlyIncomeTax = ((annualSalary - taxRules.MIN_RANGE) * taxRules.DISCOUNT / 12);
            double netMonthlyIncome = grossMonthlyIncome - monthlyIncomeTax;

            return new TaxResult()
            {
                GrossMonthlyIncome = grossMonthlyIncome,
                MonthlyIncomeTax = monthlyIncomeTax,
                NetMonthlyIncome = netMonthlyIncome
            };
        }
    }
}