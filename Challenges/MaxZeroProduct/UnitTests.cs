using Xunit;

namespace MaxZeroProduct;

public class UnitTest
{
    [Theory]
    [InlineData(new int[] { 7, 15, 6, 20, 5, 10 }, 3)]
    [InlineData(new int[] { 25, 10, 25, 10, 32 }, 4)]
    [InlineData(new int[] { 1, 2, 3, 4, 5 }, 1)]
    [InlineData(new int[] { 1, 2, 3, 4, 9, 11, 13 }, 0)]
    public void Test(int[] array, int expected)
    {
        var result = new Solution().solution(array);

        Assert.Equal(expected, result);
    }
}