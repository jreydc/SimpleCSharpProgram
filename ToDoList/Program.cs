using System;

string? userChoice;

//Main Program
List<string> todoList = new List<string>();
do
{
    userChoice = DisplayMenuAndRequireInput();
    Console.WriteLine("..............................");
} while ((userChoice != "E") && (userChoice != "e"));


static void ShowMessageResult(string descriptionMessage)
{
    Console.WriteLine(descriptionMessage);
    Console.WriteLine();
}

void PrintSelectedOption(string selectedOption)
{
    Console.WriteLine("Selected option: " + selectedOption);
    Console.WriteLine();
}

static void ShowTodoList(List<string> todoList)
{
    for (int i = 0; i < todoList.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {todoList[i]}");
    }
}



string? DisplayMenuAndRequireInput()
{
    string? userChoice;

    Console.WriteLine("TODO MENU");
    Console.WriteLine("[S]ee all TODOs");
    Console.WriteLine("[A]dd a TODO");
    Console.WriteLine("[R]emove a TODO");
    Console.WriteLine("[E]xit");
    Console.Write("What do you want to do? ");
    userChoice = Console.ReadLine();

    switch (userChoice)
    {
        case "S":
        case "s":
            PrintSelectedOption("See all TODOs"); SeeAllTODOs(); break;
        case "A":
        case "a":
            PrintSelectedOption("Add a TODO"); AddTODO(); break;
        case "R":
        case "r":
            PrintSelectedOption("Remove a TODO"); RemoveTODO(); break;
        case "E":
        case "e":
            PrintSelectedOption("Exit"); break;
        default:
            PrintSelectedOption("Out of Bounds!"); break;
    }

    return userChoice;
}

void SeeAllTODOs()
{
    if (todoList.Count == 0)
    {
        ShowMessageResult("No TODOs found");
    }
    ShowTodoList(todoList);

    Console.WriteLine();
}

void AddTODO()
{
    string descriptionMessage = string.Empty;
    bool isValidDescription;
    string? todo;
    do
    {
        Console.WriteLine("Enter a TODO Description: ");
        todo = Console.ReadLine();
        isValidDescription = (IsDescriptionValid(todo, out descriptionMessage));
        ShowMessageResult(descriptionMessage);

    } while (!isValidDescription);

    todoList.Add(todo);
    Console.WriteLine();
}

bool IsDescriptionValid(string todo, out string descriptionMessage)
{
    if (string.IsNullOrEmpty(todo))
    {
        descriptionMessage = "The description cannot be empty.";
        return false;
    }
    if (todoList.Contains(todo))
    {
        descriptionMessage = "The description must be unique.";
        return false;
    }

    descriptionMessage = "The TODO was added.";
    return true;
}

void RemoveTODO()
{
    string descriptionMessage = string.Empty;
    bool isValidIndex;
    int indexNumber;

    if (todoList.Count == 0)
    {
        ShowMessageResult("No TODOs have been added yet.");
        return;
    }
    ShowTodoList(todoList);

    do
    {
        Console.WriteLine("Select the index of the TODO you want to remove? ");
        var index = Console.ReadLine();
        isValidIndex = IsInputValid(index, out descriptionMessage, out indexNumber);
        ShowMessageResult(descriptionMessage);


    } while (!isValidIndex);
    
    RemoveTODOByIndex(todoList, indexNumber);
    Console.WriteLine();
}

bool IsInputValid(string indexInput, out string descriptionMessage, out int indexNumber)
{
    bool isIndexParsed2Number = int.TryParse(indexInput, out indexNumber);
    if (string.IsNullOrEmpty(indexInput))
    {
        descriptionMessage = "Selected index cannot be empty.";
        return false;
    }
    if (!isIndexParsed2Number)
    {
        descriptionMessage = "The given index is not valid.";
        return false;
    }
    if (indexNumber > todoList.Count || indexNumber < 0)
    {
        descriptionMessage = "The selected index does not exist.";
        return false;
    }

    descriptionMessage = $"TODO removed: {todoList[indexNumber - 1]}";
    return true;
}

Console.WriteLine("Please Any Key to Close");
Console.ReadKey();

static void RemoveTODOByIndex(List<string> todoList, int indexNumber)
{
    var index = indexNumber - 1;
    todoList.RemoveAt(index);
}