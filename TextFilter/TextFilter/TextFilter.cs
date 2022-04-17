using System.Text;

namespace TextFilter
{
    public class TextFilter : ITextFilter
    {
        private readonly IWordStream _wordStream;
        private readonly Func<string, bool> _filter;

        public TextFilter(IWordStream wordStream, Func<string, bool> filter)
        {
            _wordStream = wordStream;
            _filter = filter;
        }
        public virtual string Filter()
        {
            var sb = new StringBuilder();
            foreach (var word in _wordStream.Read().Where(x => _filter(x)))
            {
                sb.Append($"{word} ");
            }
            return sb.ToString().TrimEnd();
        }

    }
}
