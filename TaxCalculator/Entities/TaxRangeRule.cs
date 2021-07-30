using System;
using System.Collections.Generic;

namespace TaxCalculator.Entities
{
    public enum TaxRangeType
    {
        EXEMPT_RANGE = 0,
        FIRST_RANGE = 1,
        SECOND_RANGE = 2,
        THIRD_RANGE = 3,
        FOURTH_RANGE = 4,
    }

    public class TaxRangeRule
    {
        public readonly int MAX_RANGE;
        public readonly int MIN_RANGE;
        public readonly double DISCOUNT;

        public TaxRangeRule(int minRange, int maxRange, double discount)
        {
            MIN_RANGE = minRange;
            MAX_RANGE = maxRange;
            DISCOUNT = discount;
        }

        public double GetMaxMonthlyIncomeTax()
        {
            return (MAX_RANGE - MIN_RANGE) * DISCOUNT;
        }
    }

    public sealed class TaxRangeSettings
    {
        private static Dictionary<TaxRangeType, TaxRangeRule> _taxRageRules = null;
        private static TaxRangeSettings _taxRangeSettings = null;

        private TaxRangeSettings()
        {
            _taxRageRules = new Dictionary<TaxRangeType, TaxRangeRule>
            {
                { TaxRangeType.EXEMPT_RANGE, new TaxRangeRule(0, 20000, 0) },
                { TaxRangeType.FIRST_RANGE, new TaxRangeRule(20000, 40000, 0.1) },
                { TaxRangeType.SECOND_RANGE, new TaxRangeRule(40000, 80000, 0.2) },
                { TaxRangeType.THIRD_RANGE, new TaxRangeRule(80000, 180000, 0.3) },
                { TaxRangeType.FOURTH_RANGE, new TaxRangeRule(180000, Int32.MaxValue, 0.4)}
            };
        }

        public static Dictionary<TaxRangeType, TaxRangeRule> GetTaxRangeRules()
        {
            if (_taxRangeSettings == null)
            {
                _taxRangeSettings = new TaxRangeSettings();
            }

            return _taxRageRules;
        }
    }
}