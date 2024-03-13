using DiceRollGame.Utilities;

namespace DiceRollGame.UserCommunication;

public class ConsoleReader
{
    public static string ConsoleReadLine() => Console.ReadLine();

    public static int ConsoleReadIntValidation()
    {
        int userInput;
        do
        {
            DisplayCaptions.DisplayDiceMenus();
        } while (!int.TryParse(ConsoleReadLine(), out userInput));

        return userInput;
    }
}
