using System;
using Xunit;

namespace MinMaxDivision
{
    public class UnitTest1
    {
        class Solution
        {
            public int solution(int K, int M, int[] A)
            {
                var beg = 0;
                var end = (A.Length / K + A.Length % K) * M;
                var result = -1;

                while (beg <= end)
                {
                    var S = (beg + end) / 2;
                    if (check(K, S, A))
                    {
                        end = S - 1;
                        result = S;
                    }
                    else
                    {
                        beg = S + 1;
                    }
                }

                return result;
            }

            public bool check(int K, int S, int[] A)
            {
                var pos = 0;
                var sum = 0;
                while (K >= 0 && pos < A.Length)
                {
                    sum += A[pos];
                    if (sum > S)
                    {
                        K -= 1;
                        sum = 0;
                    }
                    else
                    {
                        pos += 1;
                    }
                }

                if (sum > 0)
                {
                    K -= 1;
                }

                return K >= 0;
            }
        }

        [Fact]
        public void Test1()
        {
            var A = new int[] { 2, 1, 5, 1, 2, 2, 2 };
            var K = 3;
            var M = 5;

            var sut = new Solution();

            Assert.True(sut.solution(K, M, A) == 6);
        }

        [Fact]
        public void Test2()
        {
            var A = new int[] { 2, 1, 5, 1, 2, 2 };
            var K = 3;
            var M = 5;

            var sut = new Solution();

            Assert.True(sut.solution(K, M, A) == 5);
        }

        [Fact]
        public void Test3()
        {
            var A = new int[] { 5, 5, 5, 5, 5, 5 };
            var K = 2;
            var M = 5;

            var sut = new Solution();

            Assert.True(sut.solution(K, M, A) == 15);
        }

        [Fact]
        public void Test4()
        {
            var A = new int[] { 5 };
            var K = 1;
            var M = 5;

            var sut = new Solution();

            Assert.True(sut.solution(K, M, A) == 5);
        }

        [Fact]
        public void Test5()
        {
            var A = new int[] { 0, 0, 0, 0, 0, 0 };
            var K = 3;
            var M = 0;

            var sut = new Solution();

            Assert.True(sut.solution(K, M, A) == 0);
        }

        [Fact]
        public void Test6()
        {
            var A = new int[] { 5, 3, 4, 1, 5, 5 };
            var K = 1;
            var M = 5;

            var sut = new Solution();

            Assert.True(sut.solution(K, M, A) == 23);
        }

        [Fact]
        public void Test7()
        {
            var A = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            var K = 10;
            var M = 1;

            var sut = new Solution();

            Assert.True(sut.solution(K, M, A) == 1);
        }
    }
}
