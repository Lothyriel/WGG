namespace Domain
{
    public class Term
    {
        public Term() { }
        public Term(string word, string clue)
        {
            Word = word;
            Clue = clue;
        }

        public string Word { get; }
        public string Clue { get; }
    }
}