using System.Collections.Generic;
using System.Linq;
using CustomerSumMatcher.Model;

namespace CustomerSumMatcher.Extensions
{
    public static class PartialReportItemExtensions
    {
        public static bool TryFindCombination(
            this IReadOnlyList<PartialReportItem> list, 
            decimal sum, 
            out List<PartialReportItem> result)
        {
            result = new List<PartialReportItem>();
            FindCombination(list, sum, 0, currentCombination: new List<PartialReportItem>(), result);
            return result.Any();
        }
        
        private static bool FindCombination(
            IReadOnlyList<PartialReportItem> list, 
            decimal sum, 
            int currentIndex, 
            IList<PartialReportItem> currentCombination, 
            List<PartialReportItem> result)
        {
            if (sum == 0)
            {
                result.AddRange(currentCombination);
                return true;
            }

            if (sum < 0 || currentIndex >= list.Count)
            {
                return false;
            }
            
            currentCombination.Add(list[currentIndex]);
            if (FindCombination(list, sum - list[currentIndex].Amount, currentIndex + 1, currentCombination, result))
            {
                return true;
            }

            currentCombination.RemoveAt(currentCombination.Count - 1);
            return FindCombination(list, sum, currentIndex + 1, currentCombination, result);
        }
    }
}