using System.Collections.Generic;
using System.Linq;
using CustomerSumMatcher.Extensions;
using CustomerSumMatcher.Interfaces;
using CustomerSumMatcher.Model;

namespace CustomerSumMatcher.Implementations
{
    public class CustomerSumMatcher : ICustomerSumMatcher
    {
        public IDictionary<string, IEnumerable<PartialReportItem>> Match(
            IEnumerable<PartialReportItem> partialReports,
            IEnumerable<(string CustomerNumber, decimal total)> customerTotals)
        {
            var matchedItems = new Dictionary<string, IEnumerable<PartialReportItem>>();
            var groupedPartialReports = partialReports
                .GroupBy(x => x.CustomerNumber).ToList();

            foreach (var customerTotal in customerTotals)
            {
                var customerPartialReportItems = (groupedPartialReports
                        .FirstOrDefault(y => y.Key == customerTotal.CustomerNumber) ?? Enumerable.Empty<PartialReportItem>())
                    .ToArray();
                if (customerPartialReportItems.TryFindCombination(customerTotal.total, out var result))
                    matchedItems.Add(customerTotal.CustomerNumber, result);
            }

            return matchedItems;
        }
    }
}