using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextFilter.Helpers;
using Xunit;

namespace TextFilter.Tests
{
    public class WordBorderIdentifierTests
    {
        [Theory]
        [InlineData('-', false)]
        [InlineData(' ', true)]
        [InlineData('.', true)]
        [InlineData(',', true)]
        [InlineData('a', false)]
        [InlineData('\'', false)]
        public void IsAWordBorder_ShouldWork(char character, bool expected) {
            var wordBorderIdentifier = new WordBorderIdentifier();
            var actual = wordBorderIdentifier.IsAWordBorder(character);
            Assert.Equal(expected, actual);

        }
    }
}
