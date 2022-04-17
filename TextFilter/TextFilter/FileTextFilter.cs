using TextFilter.Filters;
using TextFilter.Helpers;
using TextFilter.Streams;

namespace TextFilter
{
    // Could inherit from TextFilter and override Filter
    // Favour interface composition over inheritance
    public class FileTextFilter : ITextFilter
    {
        private readonly string _filePath;
        private readonly IFilter _lengthLessThan3Filter;
        private readonly IFilter _charTFilter;
        private readonly IFilter _middleWordVowelFilter;
        private readonly IWordBorderIdentifier _wordBorderIdentifier;
        public FileTextFilter(string path)
        {
            if (String.IsNullOrEmpty(path))
            {
                throw new ArgumentNullException("Path is empty");
            }
            if (!File.Exists(path))
            {
                throw new ArgumentNullException("File doesn't exist");
            }
            if (new FileInfo(path).Length == 0)
            {
                throw new ArgumentNullException("File is empty");
            }
            _filePath = path;
            _lengthLessThan3Filter = new LengthLimitFilter(3);
            _charTFilter = new CharFilter('t');
            _middleWordVowelFilter = new MiddleWordFilter(new char[] { 'a', 'e', 'i', 'o', 'u' });
            _wordBorderIdentifier = new WordBorderIdentifier();
        }

        public string Filter()
        {
            using (var sr = new StreamReader(_filePath))
            {
                var textFilter = new TextFilter(
                    new WordStream(_wordBorderIdentifier, sr),
                    x => !(_lengthLessThan3Filter.Filter(x) || _charTFilter.Filter(x) || _middleWordVowelFilter.Filter(x))
                    );
                return textFilter.Filter();
            }
        }
    }
}
