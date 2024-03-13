
namespace OOP_Polymorphism_Pizza;

public class Program
{
    static void Main(string[] args)
    {
        Ingredient ingredient = new Mozzarella();
        Console.WriteLine(ingredient.Name);

        var ingredients = new List<Ingredient>
        {
            new Cheddar(),
            new TomatoSauce(),
            new Mozzarella()
        };

        foreach (var ingredient in ingredients)
        {
            Console.WriteLine(ingredient.Name);
        }

        //var numbers = new List<int> { 1, 4, 6, -1, 12, 44, -8, -19 };
        //var numberSumCalculator = new NumberSumCalculator();
        //var positiveNumberSumCalculator = new PositiveNumberSumCalculator();
        //var sum = numberSumCalculator.Calculate(numbers);
        //var positiveSum = positiveNumberSumCalculator.Calculate(numbers);
        //Console.WriteLine($"The sum of the numbers is: {sum}");
        //Console.WriteLine($"The sum of the numbers is: {positiveSum}");

        Console.WriteLine("Please Press Any Key to Close!");
        Console.ReadKey();
    }
}

