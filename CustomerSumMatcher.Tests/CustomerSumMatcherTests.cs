using System.Collections.Generic;
using System.Linq;
using CustomerSumMatcher.Model;
using Xunit;

namespace CustomerSumMatcher.Tests
{
    public class CustomerSumMatcherTests
{
    [Fact]
    public void Match_WhenPartialReportsAndCustomerTotals_ThenMatchesItemsCorrectly()
    {
        var partialReports = new List<PartialReportItem>
        {
            new PartialReportItem { Amount = 12.00m, CustomerNumber = "A01", Reference = "ref1" },
            new PartialReportItem { Amount = 2.00m, CustomerNumber = "B02", Reference = "ref2" },
            new PartialReportItem { Amount = 10.00m, CustomerNumber = "A01", Reference = "ref3" },
            new PartialReportItem { Amount = 12.00m, CustomerNumber = "B02", Reference = "ref4" },
            new PartialReportItem { Amount = 100.00m, CustomerNumber = "A01", Reference = "ref5" },
            new PartialReportItem { Amount = 1000.00m, CustomerNumber = "C03", Reference = "ref6" }
        };

        var customerTotals = new List<(string CustomerNumber, decimal Total)>
        {
            ("A01", 112.00m),
            ("B02", 14.00m),
            ("C03", 1000.00m)
        };
        
        var customerSumMatcher = new Implementations.CustomerSumMatcher();

        var matchedItems = customerSumMatcher.Match(partialReports, customerTotals);
        
        Assert.Equal(3, matchedItems.Count);

        Assert.Equal(2, matchedItems["A01"].Count());
        Assert.Contains(matchedItems["A01"], x => x.Amount == 12.00m && x.Reference == "ref1");
        Assert.Contains(matchedItems["A01"], x => x.Amount == 100.00m && x.Reference == "ref5");

        Assert.Equal(2, matchedItems["B02"].Count());
        Assert.Contains(matchedItems["B02"], x => x.Amount == 12.00m && x.Reference == "ref4");
        
        Assert.Single(matchedItems["C03"]);
        Assert.Contains(matchedItems["C03"], x => x.Amount == 1000.00m && x.Reference == "ref6");
    }

    [Fact]
    public void Match_WhenNoMatches_ReturnsEmptyDictionary()
    {
        var customerSumMatcher = new Implementations.CustomerSumMatcher();

        var partialReports = new List<PartialReportItem>
        {
            new PartialReportItem { Amount = 12.00m, CustomerNumber = "A01", Reference = "ref1" },
            new PartialReportItem { Amount = 2.00m, CustomerNumber = "B02", Reference = "ref2" },
            new PartialReportItem { Amount = 10.00m, CustomerNumber = "A01", Reference = "ref3" },
            new PartialReportItem { Amount = 12.00m, CustomerNumber = "B02", Reference = "ref4" }
        };

        var customerTotals = new List<(string CustomerNumber, decimal Total)>
        {
            ("C03", 100.00m),
            ("D04", 50.00m)
        };
        var matchedItems = customerSumMatcher.Match(partialReports, customerTotals);
        
        Assert.Empty(matchedItems);
    }
}
}