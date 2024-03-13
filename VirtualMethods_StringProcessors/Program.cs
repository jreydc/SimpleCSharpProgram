
namespace VirtualMethods_StringProcessors;

public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Virtual Methods - StringProcessors!");
        List<string> words = new() { "bobcat", "wolverine", "grizzly" };

        List<string> result = words;
        var stringsProcessors = new List<StringsProcessor>
                {
                    new StringsTrimmingProcessor(),
                    new StringsUppercaseProcessor()
                };
        foreach (var stringsProcessor in stringsProcessors)
        {
            result = stringsProcessor.Process(result);
        }

        foreach (var word in result) { Console.WriteLine(word); }

        Console.WriteLine("Please Press Any Key to Close!");
        Console.ReadKey();
    }

    
}
public class StringsProcessor
{
    protected List<string> ProcessedStrings = new List<string>();
    public List<string> Process(List<string> words)
    {
        ProcessedStrings = ProcessedListOfStrings(words);
        return ProcessedStrings;
    }

    protected virtual List<string> ProcessedListOfStrings(List<string> words)
    {
        return words;
    }
}

public class StringsTrimmingProcessor : StringsProcessor
{
    protected override List<string> ProcessedListOfStrings(List<string> inputStrings)
    {
        foreach (var str in inputStrings)
        {
            // Trim each word by half
            int halfLength = str.Length / 2;
            ProcessedStrings.Add(str.Substring(0, halfLength));
        }

        return ProcessedStrings;
    }
}

public class StringsUppercaseProcessor : StringsProcessor
{
    protected override List<string> ProcessedListOfStrings(List<string> inputStrings)
    {
        foreach (var str in inputStrings)
        {
            ProcessedStrings.Add(str.ToUpper());
        }

        return ProcessedStrings;
    }
}

    
