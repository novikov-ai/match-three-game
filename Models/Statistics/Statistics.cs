namespace Models.Statistics;

public abstract class Statistics : IDisplaying
{
    private readonly IDisplaying _displaying;

    public Statistics(IDisplaying displaying)
    {
        _displaying = displaying;
    }

    /// <summary>
    /// Команда по отображению статистики
    /// </summary>
    /// <precondition>Игра существует</precondition>
    /// <postcondition>Статистика выведена в консоль</postcondtion>
    public void Display()
    {
        _displaying.Display();
    }
}

public interface IDisplaying
{
    public void Display();
}