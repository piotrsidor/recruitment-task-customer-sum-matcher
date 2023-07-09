using System;
using CustomerSumMatcher.Implementations;
using CustomerSumMatcher.Interfaces;

namespace CustomerSumMatcher
{
    class Program
    {
        static void Main(string[] args)
        {
            IReportItemsParser partialReportParser = new ReportItemsParser();
            ICustomersReportParser customersReportParser =new CustomersReportParser();
            ICustomerSumMatcher customerSumMatcher = new Implementations.CustomerSumMatcher();
            var basePath = AppDomain.CurrentDomain.BaseDirectory + "\\Data";
            var partialReportItems = partialReportParser.Parse(basePath + "\\PartialReports.csv");
            var customerTotals = customersReportParser.Parse(basePath + "\\Totals.csv");

            var result = customerSumMatcher.Match(partialReportItems, customerTotals);
        }
    }
}
