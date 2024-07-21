using CLI;

public static class Coordinator
{
    public static Position ShiftedPosition(Position startPosition, ConsoleKey key)
    {
        var endPosition = new Position()
        {
            X = startPosition.X,
            Y = startPosition.Y,
        };

        switch (key)
        {
            case ConsoleKey.UpArrow:
                System.Console.WriteLine("↑");
                endPosition.Y += 1;
                break;
            case ConsoleKey.DownArrow:
                endPosition.Y -= 1;
                System.Console.WriteLine("↓");
                break;
            case ConsoleKey.LeftArrow:
                System.Console.WriteLine("←");
                endPosition.X -= 1;
                break;
            case ConsoleKey.RightArrow:
                System.Console.WriteLine("→");
                endPosition.X += 1;
                break;
            default:
                System.Console.WriteLine("→");
                endPosition.X += 1;
                break;
        }

        return endPosition;
    }
}
