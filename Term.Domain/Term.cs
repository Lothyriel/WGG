namespace Domain
{
    public class Term
    {
        public Term(string word, string clue)
        {
            Word = word;
            Clue = clue;
        }

        public string Word { get; set; }
        public string Clue { get; set; }
    }
}