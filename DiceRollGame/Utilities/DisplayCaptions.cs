namespace DiceRollGame.Utilities;

public static class DisplayCaptions
{
    public static void DisplayDiceMenus()
    {
        Console.WriteLine("Dice Roll Game!");
        Console.WriteLine("Dice rolling.....");
        Console.Write("Guess a the number: ");
    }

    public static void DisplayDiceAfterRolling(int tries)
    {
        Console.WriteLine($"Dice rolled. Guess what number it shows in {tries} tries.");
    }

    public static void DisplayZeroedTries() => Console.WriteLine("You're out of tries.");

    public static void GameMessage(GAMERESULT isMatched)
    {
        string message = (isMatched == GAMERESULT.WIN) ? "You guessed the right number!" : "You guessed the wrong number!";
        Console.WriteLine(message);
        Console.WriteLine();
    }

}
