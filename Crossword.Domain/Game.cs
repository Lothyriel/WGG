namespace Domain
{
    public class Game
    {
        public const int WordsConstant = 2;

        private Game()
        {
            Sections = new();
        }
        public int Width { get; }
        public int Height { get; }
        public List<Section> Sections { get; }

        private bool TryAdd(Term term)
        {
            var point = new Point(0, 0, Direction.Right);
            Sections.Add(new Section(term, point));

            return true;
        }

        public static Game? Generate(List<Term> terms, int wordCount)
        {
            if (terms.Count * WordsConstant < wordCount)
                return null;

            var game = new Game();

            while (wordCount < game.Sections.Count)
            {
                terms.RemoveAll(t => game.TryAdd(t));
            }

            return game;
        }
    }
}