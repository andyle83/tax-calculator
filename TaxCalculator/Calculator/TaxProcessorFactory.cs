using TaxCalculator.Entities;

namespace TaxCalculator.Calculator
{
    public class TaxProcessorFactory
    {
        public ITaxProcessor GetTaxProcessor(int annualSalary)
        {
            var taxRangeRules = TaxRangeSettings.GetTaxRangeRules();

            if (annualSalary <= taxRangeRules[TaxRangeType.EXEMPT_RANGE].MAX_RANGE)
            {
                return new TaxProcessor(new IncomeTaxExempt());
            }

            if (annualSalary <= taxRangeRules[TaxRangeType.FIRST_RANGE].MAX_RANGE)
            {
                return new TaxProcessor(new IncomeTaxFirstRage());
            }

            if (annualSalary <= taxRangeRules[TaxRangeType.SECOND_RANGE].MAX_RANGE)
            {
                return new TaxProcessor(new IncomeTaxSecondRange());
            }

            if (annualSalary <= taxRangeRules[TaxRangeType.THIRD_RANGE].MAX_RANGE)
            {
                return new TaxProcessor(new IncomeTaxThirdRange());
            }

            return new TaxProcessor(new IncomeTaxFourthRange());
        }
    }
}