using static System.Runtime.InteropServices.JavaScript.JSType;

Console.WriteLine("Hello, Testing Area!");

PositiveAndNonPositive();

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
    for (int i = 1; i <= number; i++)
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

bool IsAnyWordLongerThan(int length, string[] words)
{
    bool isAnyWordLongerThan = false;

    foreach (var item in words)
    {
        if (item.Length > length)
        {
            isAnyWordLongerThan = true;
        }
    }

    return isAnyWordLongerThan;
}

List<string> GetOnlyUpperCaseWords(List<string> words)
{
    List<string> tempList = new List<string>();

    foreach (var item in words)
    {
        if (!(tempList.Contains(item)) && (IsAllUpper(item)))
        {
            tempList.Add(item);
        }
    }

    return tempList;
}
bool IsAllUpper(string strToCheck) //used to check if all characters in a string are uppercase and utilized in GetOnlyUpperCaseWords() method
{
    return strToCheck.All(c => char.IsUpper(c));
}

void PositiveAndNonPositive()// Sample Method utilizing the out keyword
{
    var numbers = new int[] { 10, -8, 2, 12, -17 };
    /* Check this initialization of GetOnlyPositiveAndOutNegativeNumbers with initialized int variable nonPositiveCount
     * the said variable will be passed as an out parameter from the method GetOnlyPositiveAndOutNegativeNumbers
     * and can be used to count the number of non-positive numbers
     */
    var onlyPositive = GetOnlyPositiveAndOutNegativeNumbers(numbers, out int nonPositiveCount);
    Console.WriteLine($"Count of Non Positive Numbers: {nonPositiveCount}");
    foreach (var item in onlyPositive)
    {
        Console.WriteLine(item);
    }

}

List<int> GetOnlyPositiveAndOutNegativeNumbers(int[] numbers, out int countOfNonPositive)
{
    countOfNonPositive = 0;
    var resultList = new List<int>();

    foreach (var number in numbers)
    {
        if (number > 0)
        {
            resultList.Add(number);
        }
        else
        {
            countOfNonPositive++;
        }
    }

    return resultList;
}

void TryParsingWithOutKeyword()
{
    bool isParsingSuccessful;
    do
    {
        Console.WriteLine("Enter a number: ");
        var userInput = Console.ReadLine();
        isParsingSuccessful = int.TryParse(userInput, out int number);
        if (isParsingSuccessful)
        {
            Console.WriteLine($"Number: {number}");
        }
        else
        {
            Console.WriteLine("Not a number");
        }
    } while (!isParsingSuccessful);
}