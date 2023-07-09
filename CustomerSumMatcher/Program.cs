using System;
using System.Collections.Generic;
using CustomerSumMatcher.Interfaces;
using CustomerSumMatcher.Model;

namespace CustomerSumMatcher
{
    class Program
    {
        static void Main(string[] args)
        {
            IReportItemsParser partialReportParser = null;
            ICustomersReportParser customersReportParser = null;
            ICustomerSumMatcher customerSumMatcher = null;

            var partialReportItems = partialReportParser.Parse("");
            var customerTotals = customersReportParser.Parse("");

            var result = customerSumMatcher.Match(partialReportItems, customerTotals);
        }
    }
}
