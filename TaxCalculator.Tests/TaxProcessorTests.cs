using NUnit.Framework;
using System.Collections.Generic;
using TaxCalculator.Calculator;
using TaxCalculator.Entities;

namespace TaxCalculator.Tests
{
    [TestFixture]
    public class TaxProcessorTests
    {
        private ITaxProcessor _taxProcessor;
        private TaxProcessorFactory _taxProcessorFactory;
        private static Dictionary<TaxRangeType, TaxRangeRule> rules = TaxRangeSettings.GetTaxRangeRules();

        private static int[] exempt_range = new int[] { 0, 15000, rules[TaxRangeType.EXEMPT_RANGE].MAX_RANGE };
        private static int[] first_range = new int[] { 20001, 25000, rules[TaxRangeType.FIRST_RANGE].MAX_RANGE };
        private static int[] second_range = new int[] { 40001, 45000, rules[TaxRangeType.SECOND_RANGE].MAX_RANGE };
        private static int[] third_range = new int[] { 80001, 90000, 120345, rules[TaxRangeType.THIRD_RANGE].MAX_RANGE };
        private static int[] fourth_range = new int[] { 180001, 180002, 190000, 234000 };

        [SetUp]
        public void Setup()
        {
            _taxProcessorFactory = new TaxProcessorFactory();
        }

        [Test, TestCaseSource("exempt_range")]
        public void GivenSalaryInExemptRange_ReturnCorrectNetIncome(int annualSalary)
        {
            _taxProcessor = _taxProcessorFactory.GetTaxProcessor(annualSalary);

            TaxResult taxResult = _taxProcessor.CalculateTaxFromSalary(annualSalary);

            double grossMonthlyIncome = taxResult.GrossMonthlyIncome;
            double monthlyIncomeTax = taxResult.MonthlyIncomeTax;
            double netMonthlyIncome = taxResult.NetMonthlyIncome;

            Assert.AreEqual(grossMonthlyIncome, annualSalary / 12);
            Assert.AreEqual(monthlyIncomeTax, 0);
            Assert.AreEqual(netMonthlyIncome, annualSalary / 12);
        }

        [Test, TestCaseSource("first_range")]
        public void GivenSalaryInFirstRange_ReturnCorrectNetIncome(int annualSalary)
        {
            _taxProcessor = _taxProcessorFactory.GetTaxProcessor(annualSalary);

            TaxResult taxResult = _taxProcessor.CalculateTaxFromSalary(annualSalary);

            double grossMonthlyIncome = taxResult.GrossMonthlyIncome;
            double monthlyIncomeTax = taxResult.MonthlyIncomeTax;
            double netMonthlyIncome = taxResult.NetMonthlyIncome;

            Assert.AreEqual(grossMonthlyIncome, annualSalary / 12);
            Assert.AreEqual(monthlyIncomeTax, (annualSalary - 20000) * 0.1 / 12);
            Assert.AreEqual(netMonthlyIncome, (annualSalary / 12) - (annualSalary - 20000) * 0.1 / 12);
        }

        [Test, TestCaseSource("second_range")]
        public void GivenSalaryInSecondRange_ReturnCorrectNetIncome(int annualSalary)
        {
            _taxProcessor = _taxProcessorFactory.GetTaxProcessor(annualSalary);

            TaxResult taxResult = _taxProcessor.CalculateTaxFromSalary(annualSalary);

            double grossMonthlyIncome = taxResult.GrossMonthlyIncome;
            double monthlyIncomeTax = taxResult.MonthlyIncomeTax;
            double netMonthlyIncome = taxResult.NetMonthlyIncome;

            Assert.AreEqual(grossMonthlyIncome, annualSalary / 12);
            Assert.AreEqual(monthlyIncomeTax, ((annualSalary - 40000) * 0.2 + (40000 - 20000) * 0.1) / 12);
            Assert.AreEqual(netMonthlyIncome, (annualSalary / 12) - ((annualSalary - 40000) * 0.2 + (40000 - 20000) * 0.1) / 12);
        }

        [Test, TestCaseSource("third_range")]
        public void GivenSalaryInThirdRange_ReturnCorrectNetIncome(int annualSalary)
        {
            _taxProcessor = _taxProcessorFactory.GetTaxProcessor(annualSalary);

            TaxResult taxResult = _taxProcessor.CalculateTaxFromSalary(annualSalary);

            double grossMonthlyIncome = taxResult.GrossMonthlyIncome;
            double monthlyIncomeTax = taxResult.MonthlyIncomeTax;
            double netMonthlyIncome = taxResult.NetMonthlyIncome;

            Assert.AreEqual(grossMonthlyIncome, annualSalary / 12);
            Assert.AreEqual(monthlyIncomeTax, ((annualSalary - 80000) * 0.3 + (80000 - 40000) * 0.2 + (40000 - 20000) * 0.1) / 12);
            Assert.AreEqual(netMonthlyIncome,
                (annualSalary / 12) - ((annualSalary - 80000) * 0.3 + (80000 - 40000) * 0.2 + (40000 - 20000) * 0.1) / 12);
        }

        [Test, TestCaseSource("fourth_range")]
        public void GivenSalaryInFourthRange_ReturnCorrectNetIncome(int annualSalary)
        {
            _taxProcessor = _taxProcessorFactory.GetTaxProcessor(annualSalary);

            TaxResult taxResult = _taxProcessor.CalculateTaxFromSalary(annualSalary);

            double grossMonthlyIncome = taxResult.GrossMonthlyIncome;
            double monthlyIncomeTax = taxResult.MonthlyIncomeTax;
            double netMonthlyIncome = taxResult.NetMonthlyIncome;

            Assert.AreEqual(grossMonthlyIncome, annualSalary / 12);
            Assert.AreEqual(monthlyIncomeTax,
                ((annualSalary - 180000) * 0.4 + (180000 - 80000) * 0.3 + (80000 - 40000) * 0.2 + (40000 - 20000) * 0.1) / 12);
            Assert.AreEqual(netMonthlyIncome,
                (annualSalary / 12) - ((annualSalary - 180000) * 0.4 + (180000 - 80000) * 0.3 + (80000 - 40000) * 0.2 + (40000 - 20000) * 0.1) / 12);
        }
    }
}