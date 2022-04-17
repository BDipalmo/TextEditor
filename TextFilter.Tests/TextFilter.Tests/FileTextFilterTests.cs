using Xunit;

namespace TextFilter.Tests
{
    // These tests are dependent on local machine.
    public class FileTextFilterTests
    {

        [Fact]
        public void Filter_ShouldWork() { 
            var x = new FileTextFilter(@"c:\test.txt");
            var output = x.Filter();
            Assert.Equal("Hello World How's", output);
        }
        [Fact]
        public void Filter_NonExistent_ShouldThrowException()
        {
            Assert.Throws<ArgumentNullException>(() => new FileTextFilter(@"c:\aaa.txt"));
        }
        [Fact]
        public void Filter_NullPath_ShouldThrowException()
        {
            Assert.Throws<ArgumentNullException>(() => new FileTextFilter(null));
        }
        [Fact]
        public void Filter_EmptyFile_ShouldThrowException()
        {
            Assert.Throws<ArgumentNullException>(() => new FileTextFilter(@"c:\empty.txt"));
        }
    }
}
