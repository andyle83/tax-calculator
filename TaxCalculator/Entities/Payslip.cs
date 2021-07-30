using System;

namespace TaxCalculator.Entities
{
    public class Payslip
    {
        public string FullName { get; }
        public double GrossMonthlyIncome { get; }
        public double MonthlyIncomeTax { get; }
        public double NetMonthlyIncome { get; }

        public Payslip(string fullName, double grossMonthlyIncome, double monthlyIncomeTax, double netMonthlyIncome)
        {
            FullName = fullName;
            GrossMonthlyIncome = grossMonthlyIncome;
            MonthlyIncomeTax = monthlyIncomeTax;
            NetMonthlyIncome = netMonthlyIncome;
        }

        public void PrintPayslip()
        {
            Console.WriteLine($"Monthly Payslip for: \"{FullName}\"");
            Console.WriteLine($"Gross Monthly Income: ${GrossMonthlyIncome}");
            Console.WriteLine($"Monthly Income Tax: ${MonthlyIncomeTax}");
            Console.WriteLine($"Net Monthly Income: ${NetMonthlyIncome}");
        }
    }
}