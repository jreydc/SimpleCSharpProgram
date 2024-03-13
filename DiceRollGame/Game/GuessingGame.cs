using DiceRollGame.UserCommunication;
using DiceRollGame.Utilities;

namespace DiceRollGame.Game;

public class GuessingGame()
{
    public readonly Dice? _dice;
    private int numberOfTries = 3;

    public GuessingGame(Dice dice): this()
    {
        _dice = dice;
    }

    public void Play()
    {
        int number2BeGuessed = _dice.Roll();
        int guessedNumber = 0;
        GAMERESULT result =  GAMERESULT.LOSE;
        _dice.Describe();
        while (numberOfTries > 0)
        {
            guessedNumber = ConsoleReader.ConsoleReadIntValidation();
            DisplayCaptions.DisplayDiceAfterRolling(numberOfTries);
            result = NumbersMatch4GameResult(guessedNumber, number2BeGuessed);
            DisplayCaptions.GameMessage(result);
            
            if (numberOfTries == 0 && result != GAMERESULT.WIN) DisplayCaptions.DisplayZeroedTries();
            numberOfTries--;
        }
    }

    static GAMERESULT NumbersMatch4GameResult(int guessedNumber, int number2BeGuessed)
    {
        return (guessedNumber == number2BeGuessed) ? GAMERESULT.WIN : GAMERESULT.LOSE;
    }
}