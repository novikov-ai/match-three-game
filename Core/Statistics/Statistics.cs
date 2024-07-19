namespace Core;

public class Statistics
{
    private readonly IDisplaying _displaying;

    private readonly Player _player;

    public Statistics(Player player, IDisplaying displaying)
    {
        _player = player;
        _displaying = displaying;
    }

    /// <summary>
    /// Команда по отображению статистики
    /// </summary>
    /// <precondition>Игра существует</precondition>
    /// <postcondition>Статистика выведена в консоль</postcondtion>
    public void Display()
    {
        _displaying.Display(_player);
    }
}

public interface IDisplaying
{
    public void Display(Player player);
}

public class SimpleDisplay : IDisplaying
{
    public void Display(Player player)
    {
        Console.WriteLine($"Score: {player.Score}");
        Console.WriteLine($"Moves: {player.Moves}");
    }
}