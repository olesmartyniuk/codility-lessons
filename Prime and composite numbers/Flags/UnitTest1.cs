using System;
using System.Collections.Generic;
using Xunit;

namespace Flags
{
    public class Solution
    {

        public int solution(int[] A)
        {
            if (NoPeaks(A))
                return 0;

            var distances = CalculateDistances(A);
            if (distances.Length == 0)
                return 1;

            var result = 0;
            for (int i = 1; i < distances.Length + 1; i++)
            {
                var flagsNumber = MaxFlags(distances, i);
                if (flagsNumber > result)
                {
                    result = flagsNumber;
                }
            }

            return result;
        }

        private bool NoPeaks(int[] A)
        {
            for (int i = 1; i < A.Length - 1; i++)
            {
                if (A[i - 1] < A[i] && A[i] > A[i + 1])
                    return false;
            }

            return true;
        }

        private int MaxFlags(int[] distances, int flags)
        {
            var result = 0;
            long currentDistance = 0;
            for (int i = 0; i < distances.Length; i++)
            {
                if (result == flags)
                    return result;

                currentDistance += distances[i];
                if (flags <= currentDistance)
                {
                    result++;
                    currentDistance = 0;
                }
            }

            return result + 1;
        }

        private int[] CalculateDistances(int[] A)
        {
            var result = new List<int>();
            var distance = 0;
            var peakFound = false;

            for (int i = 1; i < A.Length - 1; i++)
            {
                if (peakFound)
                    distance++;

                if (A[i - 1] < A[i] && A[i] > A[i + 1])
                {
                    if (peakFound)
                    {
                        result.Add(distance);
                        distance = 0;
                    }
                    peakFound = true;
                }
            }

            return result.ToArray();
        }
    }


    public class UnitTest1
    {
        [Theory]
        [InlineData(new int[] { 1, 5, 3, 4, 3, 4, 1, 2, 3, 4, 6, 2 }, 3)]
        [InlineData(new int[] { 0, 4, 3, 2, 1, 0, 1, 2, 3, 0 }, 2)]
        [InlineData(new int[] { 1, 2, 3, 2, 1 }, 1)]
        [InlineData(new int[] { 1, 2, 2, 1 }, 0)]
        public void Test(int[] A, int expected)
        {
            var actual = new Solution().solution(A);
            Assert.Equal(expected, actual);
        }
    }
}
