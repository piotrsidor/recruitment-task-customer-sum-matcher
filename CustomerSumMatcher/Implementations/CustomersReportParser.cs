using System.Collections.Generic;
using System.IO;
using CustomerSumMatcher.Interfaces;

namespace CustomerSumMatcher.Implementations
{
    public class CustomersReportParser : ICustomersReportParser
    {
        public IEnumerable<(string CustomerNumber, decimal Total)> Parse(string filePath)
        {
            using var reader = new StreamReader(filePath);
            while (reader.ReadLine() is { } line)
            {
                var values = line.Split(',');
                if (values.Length != 2 || !decimal.TryParse(values[0], out var total)) continue;
                
                yield return (values[1], total);
            }
        }
    }
}