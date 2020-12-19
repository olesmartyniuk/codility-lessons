using System.Collections.Generic;
using System;
using System.Linq;
using Xunit;

namespace MaxProductOfThree
{
    public class UnitTest1
    {
        class Solution
        {
            public int solution(int[] A)
            {
                var sorted = A
                    .OrderBy(a => a)
                    .ToList();

                var results = new List<int>();
                
                results.Add(sorted[0] * sorted[1] * sorted[2]);
                results.Add(sorted[0] * sorted[1] * sorted[sorted.Count - 1]);
                results.Add(sorted[0] * sorted[sorted.Count - 1] * sorted[sorted.Count - 2]);
                results.Add(sorted[sorted.Count - 1] * sorted[sorted.Count - 2] * sorted[sorted.Count - 3]);

                return results.Max();               
            }
        }

        [Theory]
        [InlineData(new int[] { -3, 1, 2, -2, 5, 6 }, 60)]
        [InlineData(new int[] { 6, 1, -2, 3, 0, 4 }, 72)]
        [InlineData(new int[] { -3, -2, 0, 6, -1, 0 }, 36)]
        [InlineData(new int[] { -3, -4, -1, -5, -2, -6 }, -6)]
        [InlineData(new int[] { 0, -4, -1, -5, -2, -6 }, 0)]
        [InlineData(new int[] { -3, -4, 1, -5, -2, -6 }, 30)]
        [InlineData(new int[] { 3, 4, -1, -1000, 10, 9 }, 10000)]
        public void Test(int[] A, int expected)
        {
            var result = new Solution().solution(A);

            Assert.True(result == expected, expected.ToString());
        }
    }
}
