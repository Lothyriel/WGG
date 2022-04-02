namespace Domain
{
    public class Section
    {
        public Section(Term term, Point point)
        {
            Term = term;
            Point = point;
        }

        public Term Term { get; }
        public Point Point { get; }
    }
    public enum Direction
    {
        Up, Down, Left, Right
    }

    public record Point(int X, int Y, Direction Direction);
}