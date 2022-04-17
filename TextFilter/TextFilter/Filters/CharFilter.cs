namespace TextFilter.Filters
{
    public class CharFilter : IFilter
    {
        private readonly char _character;

        public CharFilter(char character)
        {
            _character = Char.ToLower(character);
        }
        public bool Filter(string input) =>
            String.IsNullOrEmpty(input) 
                ? false 
                : input.ToLower().Contains(_character);
        
    }
}
