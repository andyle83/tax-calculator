using TaxCalculator.Entities;
using TaxCalculator.Helpers;

namespace TaxCalculator.Calculator
{
    public class IncomeTaxSecondRange : IIncomeTaxStrategy
    {
        virtual public TaxResult CalculateIncomeTax(int annualSalary)
        {
            var taxType = TaxRangeType.SECOND_RANGE;
            var taxRules = TaxRangeSettings.GetTaxRangeRules()[taxType];

            double grossMonthlyIncome = annualSalary / 12;
            double monthlyIncomeTax = (((annualSalary - taxRules.MIN_RANGE) * taxRules.DISCOUNT) + GetMaxIncomeInPreviousRanges(taxType)) / 12;
            double netMonthlyIncome = grossMonthlyIncome - monthlyIncomeTax;

            return new TaxResult()
            {
                GrossMonthlyIncome = grossMonthlyIncome,
                MonthlyIncomeTax = monthlyIncomeTax,
                NetMonthlyIncome = netMonthlyIncome
            };
        }

        /*
         * Calculate sum of max monthly income tax in all previous tax range
         *
         * For examples:
         * if annual salary: 30k - it will return 20k * 0.1
         * if annual salary: 50k - it will return 20k * 0.1 + (40k - 20k) * 0.2
         */

        public double GetMaxIncomeInPreviousRanges(TaxRangeType taxType)
        {
            double result = 0;
            var previousRangeTypes = EnumHelpers.GetPreValues(taxType);

            foreach (var taxRangeType in previousRangeTypes)
            {
                result += TaxRangeSettings.GetTaxRangeRules()[taxRangeType].GetMaxMonthlyIncomeTax();
            }

            return result;
        }
    }
}