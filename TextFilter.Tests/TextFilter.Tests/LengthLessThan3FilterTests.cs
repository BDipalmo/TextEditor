using TextFilter.Filters;
using Xunit;

namespace TextFilter.Tests
{
    public class LengthLessThan3FilterTests
    {
        [Theory]
        [InlineData("How", false)]
        [InlineData("to", true)]
        [InlineData("", true)]
        [InlineData(null, false)]
        public void Filter_ShouldWork(string word, bool expected)
        {
            var lengthLessThan3Filter = new LengthLimitFilter(3);
            var actual = lengthLessThan3Filter.Filter(word);
            Assert.Equal(expected, actual);
        }
    }
}
