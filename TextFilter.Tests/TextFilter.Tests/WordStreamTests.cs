using System.Text;
using TextFilter.Helpers;
using TextFilter.Streams;
using Xunit;

namespace TextFilter.Tests
{
    public class WordStreamTests
    {
        [Theory]
        [InlineData("a", new[] { "a" })]
        [InlineData("Hello World.This is a test!", new[] { "Hello", "World", "This", "is", "a", "test" })]
        [InlineData("  and looked at it,", new[] { "and", "looked", "at", "it" })]
        [InlineData("conversation?'So she ", new[] { "conversation", "So", "she"})]
        
        public void Read_ShouldWork(string input, string[] expected) {
            IWordBorderIdentifier wordBorderIdentifier = new WordBorderIdentifier();
            using (var sr = new StreamReader(new MemoryStream(Encoding.UTF8.GetBytes(input))))
            {
                var wordEnum = new WordStream(wordBorderIdentifier, sr).Read();
                Assert.Equal(expected, wordEnum);
            }
        }
        [Fact]
        public void Read_LongWord_ShouldThrowException()
        {
            var input = new String('a', 100);
            IWordBorderIdentifier wordBorderIdentifier = new WordBorderIdentifier();
            using (var sr = new StreamReader(new MemoryStream(Encoding.UTF8.GetBytes(input))))
            {
                Assert.Throws<ArgumentException>(() => new WordStream(wordBorderIdentifier, sr).Read());
            }
        }
        [Fact]
        public void Read_NullStreamReader_ShouldThrowException()
        {
            // TODO Same test for wordBorderIdentifier
            IWordBorderIdentifier wordBorderIdentifier = new WordBorderIdentifier();
            Assert.Throws<ArgumentNullException>(() => new WordStream(wordBorderIdentifier, null).Read());
            
        }
    }
}
