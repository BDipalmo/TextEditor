using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextFilter.Filters;
using Xunit;

namespace TextFilter.Tests
{
    public class CharTFilterTests
    {
        [Theory]
        [InlineData(null, false)] // add to other tests - handle nulls
        [InlineData("", false)]
        [InlineData("t", true)]
        [InlineData("hello", false)]
        [InlineData("this", true)]
        [InlineData("This", true)]
        public void Filter_ShouldWork(string word, bool expected)
        {
            var charTFilter = new CharFilter('t');
            var actual = charTFilter.Filter(word);
            Assert.Equal(expected, actual);
        }
    }
}
