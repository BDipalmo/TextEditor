namespace TextFilter.Filters
{
    public class MiddleWordFilter : IFilter
    {
        private readonly IEnumerable<char> _permittedCharacterList;

        public MiddleWordFilter(IEnumerable<char> permittedCharacterList)
        {
            _permittedCharacterList = permittedCharacterList.Select(x => Char.ToLower(x));
        }
        public string GetMiddleCharacters(string input)
        {
            if (String.IsNullOrEmpty(input))
            {
                return "";
            }
            
            return input.Length % 2 == 1
                ? input.Substring(input.Length / 2, 1)
                : input.Substring((input.Length / 2) - 1, 2);
        }
        public bool Filter(string input)
        {
            if (String.IsNullOrEmpty(input) || _permittedCharacterList.Count() == 0)
            {
                return false;
            }
            var middleCharacters = GetMiddleCharacters(input);
            foreach (var x in _permittedCharacterList)
            {
                if (middleCharacters.ToLower().Contains(x))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
