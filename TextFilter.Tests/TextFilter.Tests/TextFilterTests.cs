using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextFilter.Filters;
using TextFilter.Helpers;
using TextFilter.Streams;
using Xunit;

namespace TextFilter.Tests
{
    public class TextFilterTests
    {
        // Turn this into a FileFilter.
        [Fact]
        public void Filter_ShouldWork()
        {
            var lengthLessThan3Filter = new LengthLimitFilter(3);
            var charTFilter = new CharFilter('t');
            var middleWordVowelFilter = new MiddleWordFilter(new char[] { 'a', 'e', 'i', 'o', 'u' });
            var wordBorderIdentifier = new WordBorderIdentifier();
            using (var sr = new StreamReader(new MemoryStream(Encoding.UTF8.GetBytes("the Rabbit actually took a watchout of its waistcoat pocket, and looked at it,"))))
            {
                var textFilter = new TextFilter(
                    new WordStream(wordBorderIdentifier, sr),
                    x => !(lengthLessThan3Filter.Filter(x) || charTFilter.Filter(x) || middleWordVowelFilter.Filter(x))
                    );
                var output = textFilter.Filter();
                Assert.Equal("and", output);
            }
        }
    }
}
