
Console.WriteLine("Grade Equivalentor");
Console.WriteLine("Enter points: ");
var points = int.Parse(Console.ReadLine());
Console.WriteLine($"Equivalent: {Equivalent(points)}");

char Equivalent(int points)
{
    switch (points)
    {
        case 10: case 9:
            return 'A'; 
        case 8: case 7: case 6:
            return 'B';
        case 5: case 4: case 3:
            return 'C';
        case 2: case 1:
            return 'D';
        default:
            return '!';
    }
}

Console.WriteLine("Press Any Key to Close");
Console.ReadKey();
