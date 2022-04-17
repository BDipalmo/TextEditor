namespace TextFilter.Filters
{
    public class LengthLimitFilter : IFilter
    {
        private readonly int _size;

        public LengthLimitFilter(int size)
        {
            _size = size;
        }
        public bool Filter(string input) => 
            input == null
                ? false
                : input.Length < _size;
    }
}
