using NUnit.Framework;
using System;
using System.Linq;
using TaxCalculator.Entities;
using TaxCalculator.Helpers;

namespace TaxCalculator.Tests
{
    [TestFixture]
    internal class HelperTests
    {
        [TestCase(TaxRangeType.EXEMPT_RANGE)]
        public void GivenFirstEnumElement_ReturnAnEmptyList(TaxRangeType type)
        {
            var result = EnumHelpers.GetPreValues(type);

            Assert.AreEqual(Enumerable.Count(result), 0);
        }

        [TestCase(TaxRangeType.FOURTH_RANGE)]
        public void GivenLastEnumElement_ReturnAllPreviousElementInList(TaxRangeType type)
        {
            var result = EnumHelpers.GetPreValues(type);
            var total = Enum.GetNames(typeof(TaxRangeType)).Length;

            Assert.AreEqual(Enumerable.Count(result), total - 1);
        }
    }
}