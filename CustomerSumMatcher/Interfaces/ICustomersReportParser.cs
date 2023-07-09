using System.Collections.Generic;

namespace CustomerSumMatcher.Interfaces
{
    public interface ICustomersReportParser
    {
        IEnumerable<(string CustomerNumber, decimal Total)> Parse(string filePath);
    }
}