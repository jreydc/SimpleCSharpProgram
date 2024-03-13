using DiceRollGame.Game;
using DiceRollGame.Utilities;

namespace DiceRollGame;
public class Program
{
    static void Main(string[] args)
    {
        var _dice = new Dice(new Random());
        var game = new GuessingGame(_dice);
        game.Play();
        
        Console.WriteLine();
        Console.WriteLine("Please Press Any Key!");
        Console.ReadKey();
    }

}
