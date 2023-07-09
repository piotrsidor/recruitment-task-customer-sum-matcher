using System.Collections.Generic;
using System.IO;
using CustomerSumMatcher.Interfaces;
using CustomerSumMatcher.Model;

namespace CustomerSumMatcher.Implementations
{
    public class ReportItemsParser : IReportItemsParser
    {
        public IEnumerable<PartialReportItem> Parse(string filePath)
        {
            using var reader = new StreamReader(filePath);
            while (reader.ReadLine() is { } line)
            {
                var values = line.Split(',');

                if (values.Length != 3 || !decimal.TryParse(values[0], out var amount)) continue;
                yield return new PartialReportItem
                {
                    Amount = amount,
                    CustomerNumber = values[1],
                    Reference = values[2]
                };
            }
        }
    }
}