using System;
using System.Collections.Generic;
using Xunit;

namespace StoneWall
{

    class Solution
    {
        public int solution(int[] H)
        {
            var result = 0;

            var stack = new Stack<int>();
            for (int i = 0; i < H.Length; i++)
            {
                if (H[i] == stack.Top())
                {
                    continue;
                }

                if (H[i] > stack.Top())
                {
                    result++;
                    stack.Push(H[i]);
                }
                else
                {
                    while (stack.Top() > H[i])
                    {
                        stack.Pop();
                    }

                    if (stack.Top() < H[i])
                    {
                        result++;
                        stack.Push(H[i]);
                    }
                }
            }

            return result;
        }
    }

    public static class StackExtensions
    {
        public static int Top(this Stack<int> stack, int def = 0)
        {
            if (stack.Count == 0)
                return def;
            return stack.Peek();            
        }
    }

    public class UnitTest1
    {
        [Theory]
        [InlineData(new int[] { 8, 8, 5, 7, 9, 8, 7, 4, 8 }, 7)]
        [InlineData(new int[] { 1, 2, 2, 1 }, 2)]
        [InlineData(new int[] { 1, 2, 2, 3, 1 }, 3)]
        [InlineData(new int[] { 1, 2, 2, 3, 4, 1 }, 4)]
        [InlineData(new int[] { 1, 2 }, 2)]
        [InlineData(new int[] { 1, 2, 1, 3, 1 }, 3)]
        [InlineData(new int[] { 1, 2, 3, 2, 1 }, 3)]
        public void Test(int[] H, int expected)
        {
            var result = new Solution().solution(H);
            Assert.Equal(expected, result);
        }
    }
}
