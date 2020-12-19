using System;
using Xunit;

namespace Sorting
{
    class Solution
    {
        public int[] SelectionSort(int[] input)
        {
            for (var i = 0; i < input.Length; i++)
            {
                var min = i;
                for (var j = i + 1; j < input.Length; j++)
                {
                    if (input[j] < input[min])
                    {
                        min = j;
                    }
                }

                var temp = input[i];
                input[i] = input[min];
                input[min] = temp;
            }

            return input;
        }

        public int[] CountingSort(int[] input)
        {
            var counts = new int[1000];

            for (var i = 0; i < input.Length; i++)
            {
                counts[input[i]] += 1;
            }

            var result = new int[input.Length];
            var n = 0;
            for (var i = 0; i < counts.Length; i++)
            {
                for (var j = 0; j < counts[i]; j++)
                {
                    result[n] = i;
                    n += 1;
                }
            }

            return result;
        }

        public int[] MergeSort(int[] input)
        {
            if (input.Length == 1)
            {
                return input;
            }

            var half = input.Length / 2;

            var left = MergeSort(input.SubArray(0, half));
            var right = MergeSort(input.SubArray(half, input.Length - half));

            var result = new int[input.Length];
            var i = 0;
            var j = 0;
            var n = 0;

            while (true)
            {
                if (i == left.Length && j == right.Length)
                {
                    break;
                }

                if (i == left.Length)
                {
                    result[n] = right[j];
                    j++;
                    n++;
                    continue;
                }

                if (j == right.Length)
                {
                    result[n] = right[i];
                    i++;
                    n++;
                    continue;
                }

                if (left[i] < right[j])
                {
                    result[n] = left[i];
                    i++;
                    n++;
                }
                else
                {
                    result[n] = right[j];
                    j++;
                    n++;
                }
            }

            return result;
        }
    }

    public static class Extensions
    {
        public static T[] SubArray<T>(this T[] array, int offset, int length)
        {
            T[] result = new T[length];
            Array.Copy(array, offset, result, 0, length);
            return result;
        }
    }

    public class UnitTest1
    {
        [Theory]
        [InlineData(new int[] { 5, 2, 8, 14, 1, 16 }, new int[] { 1, 2, 5, 8, 14, 16 })]
        public void TestSelectionSort(int[] input, int[] expected)
        {
            var result = new Solution().SelectionSort(input);

            for (var i = 0; i < result.Length; i++)
            {
                Assert.True(result[i] == expected[i]);
            }
        }

        [Theory]
        [InlineData(new int[] { 5, 2, 8, 14, 1, 16 }, new int[] { 1, 2, 5, 8, 14, 16 })]
        public void TestCountingSort(int[] input, int[] expected)
        {
            var result = new Solution().CountingSort(input);

            for (var i = 0; i < result.Length; i++)
            {
                Assert.True(result[i] == expected[i]);
            }
        }

        [Theory]
        [InlineData(new int[] { 5, 2, 8, 14, 1, 16 }, new int[] { 1, 2, 5, 8, 14, 16 })]
        public void TestMergeSort(int[] input, int[] expected)
        {
            var result = new Solution().MergeSort(input);

            for (var i = 0; i < result.Length; i++)
            {
                Assert.True(result[i] == expected[i]);
            }
        }
    }
}
