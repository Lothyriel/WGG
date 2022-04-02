namespace Domain
{
    public class Game
    {
        private Game()
        {
            Sections = new();
        }
        public int Width { get; }
        public int Height { get; }
        public List<Section> Sections { get; }

        private Point TryAdd(Term term)
        {
            throw new Exception();
            return null;
        }

        public static Game Generate()
        {
            var wordCount = Random.Shared.Next(30, 41);
            var game = new Game();

            while (wordCount < game.Sections.Count)
                game.TryAdd(null);

            return game;
        }
    }
}