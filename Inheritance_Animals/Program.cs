namespace Inheritance_Animals;

public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Inheritance and Overriding - Animals!");
        var animals = new List<Animal>()
        {
            new Lion(),
            new Tiger(),
            new Duck(),
            new Spider()
        };
        foreach (var animal in animals)
        {
            Console.WriteLine($"The {animal.GetType().Name} has {animal.NumberOfLegs} legs.");
        }

        Console.WriteLine("Please Press Any Key to Close!");
        Console.ReadKey();
    }
}

public class Animal
{
    public virtual int NumberOfLegs { get; } = 4;
}

public class Lion : Animal
{
    public int NumberOfLegs => 4;
}

public class Tiger : Animal
{
    public int NumberOfLegs => 4;
}

public class Duck : Animal
{
    public override int NumberOfLegs => 2;
}

public class Spider : Animal
{
    public override int NumberOfLegs => 8;
}

