using System.Security.Principal;

Console.WriteLine("Hello from the Calculator project");
Console.WriteLine("Input the first number: ");
var firstNumber = int.Parse(Console.ReadLine());
Console.WriteLine("Input the second number: ");
var secondNumber = int.Parse(Console.ReadLine());

Console.WriteLine("[A]dd");
Console.WriteLine("[S]ubtract");
Console.WriteLine("[M]ultiply");
Console.WriteLine("[D]ivide");
Console.WriteLine("What do you want to do with those numbers?: ");
string selectedOption = Console.ReadLine();

ProcessSelectedOption(selectedOption, firstNumber, secondNumber);

void ProcessSelectedOption(string choice, int fNum, int sNum)
{
    string selectedOperation = string.Empty;
    
    if (choice == "A")
    {
        selectedOperation = "Addition";
        Add(fNum, sNum);
    }else if (choice == "S")
    {
        selectedOperation = "Subtraction";
        Subtract(fNum, sNum);
    }else if (choice == "M")
    {
        selectedOperation = "Multiplication";
        Multiply(fNum, sNum);
    }
    else if (choice == "D")
    {
        selectedOperation = "Division";
        Divide(fNum, sNum);
    }
    else
    {
        selectedOperation = "Invalid";
    }
    Console.WriteLine("You chose {0}", selectedOperation);
}

void Add(int firstNumber, int secondNumber)
{
    Console.WriteLine("{0} + {1} = {2}", firstNumber, secondNumber, firstNumber + secondNumber);
}

void Subtract(int firstNumber, int secondNumber)
{
    Console.WriteLine("{0} - {1} = {2}", firstNumber, secondNumber, firstNumber - secondNumber);
}

void Multiply(int firstNumber, int secondNumber)
{
    Console.WriteLine("{0} x {1} = {2}", firstNumber, secondNumber, firstNumber * secondNumber);
}

void Divide(int firstNumber, int secondNumber)
{
    Console.WriteLine("{0} / {1} = {2}", firstNumber, secondNumber, firstNumber / secondNumber);
}


Console.WriteLine("Press Any Key to Close");
Console.ReadKey();

