using TaxCalculator.Entities;

namespace TaxCalculator.Parser
{
    public interface IParser
    {
        public Employee InputParse(string[] input);
    }
}