using System;
using TaxCalculator.Calculator;
using TaxCalculator.Entities;
using TaxCalculator.Exceptions;
using TaxCalculator.Parser;

namespace TaxCalculator
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            TaxProcessorFactory taxProcessorFactory = new TaxProcessorFactory();
            IParser inputParser = new ConsoleParser();

            try
            {
                // Parse data from console input
                Employee employee = inputParser.InputParse(args);

                // Get and use tax processor
                ITaxProcessor taxProcessor = taxProcessorFactory.GetTaxProcessor(employee.AnnualSalary);
                TaxResult taxResult = taxProcessor.CalculateTaxFromSalary(employee.AnnualSalary);

                // Get payslip and print out
                Payslip payslip = new Payslip(employee.FullName, taxResult.GrossMonthlyIncome, taxResult.MonthlyIncomeTax, taxResult.NetMonthlyIncome);
                payslip.PrintPayslip();
            }
            catch (InsufficientTaxInputException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (InvalidTaxSalaryInputException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occured when parsing input " + ex.Message);
            }
        }
    }
}