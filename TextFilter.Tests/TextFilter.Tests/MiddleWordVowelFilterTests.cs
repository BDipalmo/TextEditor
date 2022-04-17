using TextFilter.Filters;
using Xunit;

namespace TextFilter.Tests
{
    public class MiddleWordVowelFilterTests
    {
        [Theory]
        [InlineData("Hello", "l")]
        [InlineData("World", "r")]
        [InlineData("macadamia", "d")]
        [InlineData("strawberry", "wb")]
        [InlineData("I", "I")]
        [InlineData("wOs", "O")]
        [InlineData("here", "er")]
        [InlineData("", "")]
        [InlineData(null, "")]
        public void GetMiddleCharacters_ShouldWork(string word, string expected)
        {
            var middleWordVowelFilter = new MiddleWordFilter(new char[] { 'a', 'e', 'i', 'o', 'u' });
            var actual = middleWordVowelFilter.GetMiddleCharacters(word);
            Assert.Equal(expected, actual);

        }
        
        [Theory]
        [InlineData("Hello", false)]
        [InlineData("WoRld", false)]
        [InlineData("macadamia", false)]
        [InlineData("strawberry", false)]
        [InlineData("I", true)]
        [InlineData("wOs", true)]
        [InlineData("wos", true)]
        [InlineData("here", true)]
        [InlineData("abba", false)]
        [InlineData("saas", true)]
        [InlineData("", false)]
        [InlineData(null, false)]
        public void Filter_ShouldWork(string word, bool expected)
        {
            var middleWordVowelFilter = new MiddleWordFilter(new char[] { 'a', 'e', 'i', 'o', 'u' });
            var actual = middleWordVowelFilter.Filter(word);
            Assert.Equal(expected, actual);
        }
    }
}
