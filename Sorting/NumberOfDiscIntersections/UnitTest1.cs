using System;
using Xunit;
using Xunit.Abstractions;

namespace NumberOfDiscIntersections
{

    class Solution
    {
        private ITestOutputHelper output;

        public Solution(ITestOutputHelper output)
        {
            this.output = output;
        }

        public int solution(int[] A)
        {
            var result = 0;

            for (var i = 0; i < A.Length; i++)
            {
                if (i + A[i] >= A.Length - 1)
                {
                    result += A.Length - 1 - i;
                    if (result > 10_000_000)
                    {
                        return -1;
                    }
                    continue;
                }
                else
                {
                    result += A[i];
                    if (result > 10_000_000)
                    {
                        return -1;
                    }

                    for (var j = i + A[i] + 1; j < A.Length; j++)
                    {
                        if (Intersect(A, i, j))
                        {
                            result++;
                            if (result > 10_000_000)
                            {
                                return -1;
                            }
                        }
                    }

                }
            }

            return result;
        }

        private bool Intersect(int[] A, int i, int j)
        {
            var iLeft = i - A[i];
            var iRight = i + A[i];
            var jLeft = j - A[j];
            var jRight = j + A[j];

            var notIntersected = (iRight < jLeft && i < j) || (jRight < iLeft && i > j);

            return !notIntersected;
        }
    }

    public class UnitTest1
    {
        private readonly ITestOutputHelper output;

        public UnitTest1(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Theory]
        [InlineData(new int[] { 1, 5, 2, 1, 4, 0 }, 11)]
        [InlineData(new int[] { 1, 0, 0, 1 }, 2)]
        [InlineData(new int[] { 1, 0, 0, 0 }, 1)]
        [InlineData(new int[] { 0, 0, 0, 0 }, 0)]
        public void Test1(int[] A, int expected)
        {
            var res = new Solution(output).solution(A);
            Assert.True(res == expected);
        }
    }
}
