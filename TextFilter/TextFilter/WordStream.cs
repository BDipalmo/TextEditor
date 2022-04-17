using System.Text;
using TextFilter.Helpers;

namespace TextFilter.Streams
{
    public class WordStream : IWordStream
    {
        private readonly IWordBorderIdentifier _delineater;
        private readonly StreamReader _streamReader;

        public WordStream(IWordBorderIdentifier delineater, StreamReader streamReader)
        {
            _delineater = delineater;
            if (streamReader == null)
            {
                throw new ArgumentNullException("StreamReader is null");
            }
            _streamReader = streamReader;
        }
        public IEnumerable<string> Read()
        {
            var sb = new StringBuilder(); 
            var wordDetected = false;

            while (_streamReader.Peek() >= 0)
            {
                var character = (char)_streamReader.Read();
                if (_delineater.IsAWordBorder(character))
                {
                    if (wordDetected)
                    {
                        yield return sb.ToString();
                        sb.Clear();
                        wordDetected = false;
                    }
                }
                else
                {
                    sb.Append(character);
                    wordDetected = true;
                    if (sb.Length > 50) { //Arbituary Max word size, possible indication of a text input issue.
                        throw new ArgumentException("Max word size exceeded.");
                    }
                }
            }
            if (sb.Length > 0)
            {
                yield return sb.ToString();
            }
            
        }
    }
}
