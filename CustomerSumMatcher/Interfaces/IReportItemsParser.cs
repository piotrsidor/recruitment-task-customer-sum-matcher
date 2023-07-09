using System.Collections.Generic;
using CustomerSumMatcher.Model;

namespace CustomerSumMatcher.Interfaces
{
    public interface IReportItemsParser
    {
        IEnumerable<PartialReportItem> Parse(string filePath);
    }
}