using TaxCalculator.Entities;

namespace TaxCalculator.Calculator
{
    internal class IncomeTaxFourthRange : IncomeTaxSecondRange
    {
        override public TaxResult CalculateIncomeTax(int annualSalary)
        {
            var taxType = TaxRangeType.FOURTH_RANGE;
            var taxRules = TaxRangeSettings.GetTaxRangeRules()[taxType];

            double grossMonthlyIncome = annualSalary / 12;
            double monthlyIncomeTax = ((annualSalary - taxRules.MIN_RANGE) * taxRules.DISCOUNT + GetMaxIncomeInPreviousRanges(taxType)) / 12;
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