namespace CustomerSumMatcher.Model
{
    public class PartialReportItem
    {
        public int Id { get; set; }
        public string CustomerNumber { get; set; }
        public decimal Amount { get; set; }
        public string Reference { get; set; }
    }
}