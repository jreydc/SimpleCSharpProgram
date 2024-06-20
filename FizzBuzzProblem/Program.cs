// See https://aka.ms/new-console-template for more information
Console.WriteLine("FizzBuzz Problem!");

Console.WriteLine("Enter any number: ");
var n = Convert.ToInt32(Console.ReadLine()?.Trim());

var result = new FizzBuzz(n);

Console.WriteLine(result);
Console.WriteLine("Please Press Any Key!");
Console.ReadKey();

public class FizzBuzz
{
    private const int MinValue = 1;

    public FizzBuzz(int n)
    {
        Execute(n);
    }

    public void Execute(int n)
    {
        Enumerable.Range(MinValue, n)
                  .Select(i => (i % 3 == 0, i % 5 == 0) switch
                  {
                      (true, true) => "FizzBuzz",
                      (true, false) => "Fizz",
                      (false, true) => "Buzz",
                      _ => i.ToString()
                  })
                  .ToList()
                  .ForEach(Console.WriteLine);
    }
}