using System.Collections.Generic;
using CustomerSumMatcher.Model;

namespace CustomerSumMatcher.Interfaces
{
    public interface ICustomerSumMatcher
    {
        IDictionary<string, IEnumerable<PartialReportItem>> Match(IEnumerable<PartialReportItem> partialReports,
                    IEnumerable<(string CustomerNumber, decimal total)> customerTotals);
    }
}