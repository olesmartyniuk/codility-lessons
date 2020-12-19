using System;
using Xunit;

namespace MissingInteger
{
    public class UnitTest1
    {
        class Solution
        {
            public int solution(int[] A)
            {
                var count = new int[1000_001];
                
                for (var i = 0; i < A.Length; i++)
                {
                    if (A[i] > 0)
                    {
                        count[A[i]] = 1;
                    }                    
                }

                for (var i = 1; i < count.Length; i++)
                {
                    if (count[i] == 0)
                    {
                        return i;
                    }
                }

                return count.Length + 1;
            }
        }

        [Theory]
        [InlineData(new int[] { 1, 3, 6, 4, 1, 2 }, 5)]
        [InlineData(new int[] { 1, 2, 3 }, 4)]
        [InlineData(new int[] { -1, -3 }, 1)]
        public void Test(int[] A, int expected)
        {
            var result = new Solution().solution(A);
            Assert.True(result == expected);
        }
    }
}
