using static System.Runtime.InteropServices.JavaScript.JSType;

Console.WriteLine("Hello, Testing Area!");



Console.WriteLine("Press Any Key to Close!");
Console.ReadKey();

int CalculateSumOfNumbersBetween(int firstNumber, int lastNumber)
{
    int previousSum = 0;

    while (firstNumber <= lastNumber)
    {
        previousSum += firstNumber;
        firstNumber++;
        
    }

    return (previousSum);
}

string RepeatCharacter(char character, int targetLength)
{
    string repeat = string.Empty;
    int counter = 1;
    do
    {
        repeat += character;
        counter++;
    } while ((counter <= targetLength) && !(targetLength <= 0));

    return repeat;
}

int Factorial(int number)
{
    int sumFactorial = 0;
    for (int i=1; i <= number; i++)
    {
        sumFactorial *= i;
    }
    return sumFactorial;
}

string BuildHelloString()
{
    char[] letters = { 'h', 'e', 'l', 'l', 'o' };
    var result = "";
    for (int i = 0; i < letters.Length; ++i)
    {
        result += letters[i];
    }
    return result;
}

bool IsWordPresentInCollection(string[] words, string wordToBeChecked)
{
    bool isWordPresent = false;
    for (int i = 0; i < words.Length; i++)
    {
        if (words[i] == wordToBeChecked)
        {
            isWordPresent = true;
            return isWordPresent;
            break;
        }
    }

    return isWordPresent;
}

int FindMax(int[,] numbers)
{
    int currentMaxValue;
    var height = numbers.GetLength(0);
    var width = numbers.GetLength(1);

    if (height == 0 || width == 0)
    {
        currentMaxValue = -1;

    }
    else
    {
        currentMaxValue = numbers[0, 0];

        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                if (numbers[i, j] > currentMaxValue)
                {
                    currentMaxValue = numbers[i, j];
                }
            }
        }
    }

    return currentMaxValue;
}