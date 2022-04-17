namespace TextFilter.Helpers
{
    public class WordBorderIdentifier : IWordBorderIdentifier
    {
        public bool IsAWordBorder(char character)
        {
            if (character == 39) return false; //' e.g assumes He's is a single word.  But causes quotations to be picked up.
            if (character == 45) return false; //-

            return Char.IsWhiteSpace(character) || (Char.IsPunctuation(character));

        }
    }
}
