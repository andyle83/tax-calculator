using System;
using System.Collections.Generic;
using System.Linq;
using TaxCalculator.Entities;

namespace TaxCalculator.Helpers
{
    public class EnumHelpers
    {
        /**
         * Give an enum element, it will return all previous elements
         */

        public static IEnumerable<TaxRangeType> GetPreValues(TaxRangeType value)
        {
            var values = Enum.GetValues(typeof(TaxRangeType)).Cast<TaxRangeType>();

            return (from item in values
                    where item.CompareTo(value) < 0
                    select item);
        }
    }
}