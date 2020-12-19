using System;
using Xunit;

namespace BinaryGap
{
    public class UnitTest1
    {
        class Solution
        {            
            public int solution(int N)
            {
                var maxGap = 0;
                var currentGap = 0;
                var isGapOpened = false;

                while (N > 0)
                {
                    var reminder = N % 2;
                    N = N / 2;

                    if (reminder == 1 && isGapOpened)
                    {
                        if (currentGap > maxGap)
                        {
                            maxGap = currentGap;
                        }
                        isGapOpened = false;
                    }

                    if (reminder == 1 && !isGapOpened)
                    {
                        isGapOpened = true;
                        currentGap = 0;
                    }

                    if (reminder == 0 && isGapOpened)
                    {
                        currentGap++;
                    }
                }

                return maxGap;
            }
        }

        [Theory]
        [InlineData(9, 2)]
        [InlineData(529, 4)]
        [InlineData(20, 1)]
        [InlineData(32, 0)]
        [InlineData(1041, 5)]
        public void Test(int value, int maxBinaryGap)
        {
            var sut = new Solution();

            Assert.True(sut.solution(value) == maxBinaryGap);
        }
    }
}
