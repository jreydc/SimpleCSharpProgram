string? userChoice;

//Main Program
List<string> todoList = new List<string>();

do
{
    
    Console.WriteLine("............................");
    Console.WriteLine("TODO Menu");
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
} while (userChoice != "E" && userChoice != "e");


void PrintSelectedOption(string selectedOption)
{
    Console.WriteLine("Selected option: " + selectedOption);
}

void ShowTodoList(List<string> todoList)
{
    for (int i = 0; i < todoList.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {todoList[i]}");
    }
}

void SeeAllTODOs()
{
    string descriptionMessage = string.Empty;
    if (todoList.Count == 0)
    {
        descriptionMessage = ("No TODOs found");
    }

    ShowTodoList(todoList);

    Console.WriteLine(descriptionMessage);
    Console.WriteLine();
}

void AddTODO()
{
    string descriptionMessage = string.Empty;
    bool isValidDescription = false;
    string? todo;
    do
    {
        Console.WriteLine("Enter a TODO Description: ");
        todo = Console.ReadLine();
        if (string.IsNullOrEmpty(todo))
        {
            descriptionMessage = "The description cannot be empty.";
        }
        else if (todoList.Contains(todo))
        {
            descriptionMessage = "The description must be unique.";
        }
        else
        {
            isValidDescription = true;
            todoList.Add(todo);
            descriptionMessage = "The TODO was added.";
        }

        Console.WriteLine(descriptionMessage);
    } while (!isValidDescription);

    
    Console.WriteLine();
}

void RemoveTODO()
{
    string descriptionMessage = string.Empty;
    bool isValidIndex = false;
    int indexNumber;

    if (todoList.Count == 0)
    {
        descriptionMessage = "No TODOs have been added yet.";
        return;
    }
    ShowTodoList(todoList);

    do
    {
        Console.WriteLine("Select the index of the TODO you want to remove? ");
        var indexInput = Console.ReadLine();
        bool isIndexParsed2Number = int.TryParse(indexInput, out indexNumber);
        if (string.IsNullOrEmpty(indexInput))
        {
            descriptionMessage = "Selected index cannot be empty.";
        }
        else if (!isIndexParsed2Number)
        {
            descriptionMessage = "The given index is not valid.";
        }
        else if (indexNumber > todoList.Count || indexNumber < 0)
        {
            descriptionMessage = "The selected index does not exist.";
        }
        else
        {
            isValidIndex = true;
            var index = indexNumber - 1;
            todoList.RemoveAt(index);
            descriptionMessage = $"TODO removed: {todoList[index]}";
        }

    } while (!isValidIndex);

    Console.WriteLine(descriptionMessage);
    Console.WriteLine();
}


Console.WriteLine("Please Enter Any Key to Close!");
Console.ReadKey();