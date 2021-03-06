# Tax-Calculator

This is a simple Tax Calculator console application to calculate an employee's annual salary and print out tax information to the screen.

# Solution approach

In general design solution, the application should include three main components:

- Input Parse - `ConsoleParser`: help application handle the input from console and save data in `Employee`
- Tax Processor - `TaxProcessor`: calculate tax information with different annual salary ranges
- Payslip - `Payslip`: keep payslip data and print out data to the screen

The most important part in this solution is how we can process tax data with various dependent conditions:

- Tax Ranges (i.e, 0 - 20k, 20k - 40k...)
- Different discounts in each range (0.1c, 0.2c etc..)

The solution should be maintainable and flexible to extend when we add more logic of calculations. Therefore, it chose `Strategy pattern` to encapsulate logic of tax calculation in different concrete classes (`IncomeTaxExempt`, `IncomeTaxFirstRange` ...). A context class `TaxProcessorFactory` will base on annual salary value to choose which way to calculate tax.

# Solution trade-off

- Pros:
  - Allow to apply TDD with different tax calculation strategies, make sure we have correct tax calculation results.
  - Since the logic of tax calculation  is encapsulated in some concrete classes, it is easy to maintain or extend.
- Cons:
  - Some concrete strategy classes will have duplicated code (`IncomeTaxFirstRange`, `IncomeTaxSecondRange`...)

There are some coding drawbacks that can be improved:
- Tax duration should move to constant
- Testing data are still fixed with some parameters. If setting class (`TaxRangeRule`) is updated, test cases have to be updated too.

# Run application

The application is implemented with C#, using dotnet core and NUnit test framework. 

- To build or test application, we can use Visual Studio (i am using Visual Studio 2019 )
- To run application, running `TaxCalculator.exe` in `bin\Debug\netcoreapp3.1` folder with input format as required.