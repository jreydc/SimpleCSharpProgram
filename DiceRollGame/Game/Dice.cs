namespace DiceRollGame.Game;

public class Dice
{
    private readonly Random random;
    //private readonly int SidesCount;
    private const int SidesCount = 6;

    public Dice(Random random)
    {
        this.random = random;
    }

    public int Roll() => random.Next(1, SidesCount + 1);

    public void Describe() => Console.WriteLine($"This dice has {SidesCount} sides.");
}
