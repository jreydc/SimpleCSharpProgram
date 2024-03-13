namespace VirtualMethods_StringProcessors;

public class StringDuplicationMainProgram
{
    static void StringDuplicationMain()
    {
        Console.WriteLine("Virtual Methods - StringProcessors!");
        List<string> words = new() { "bobcat", "wolverine", "grizzly" };

        List<string> result = new List<string>();
        var stringsProcessors = new List<StringDuplicationProcessor>
                {
                    new StringDuplicationTrimmingProcessor(),
                    new StringDuplicationToUppercaseProcessor()
                };
        foreach (var stringsProcessor in stringsProcessors)
        {
            result = stringsProcessor.Process(words);
        }

        foreach (var word in result) { Console.WriteLine(word); }

        Console.WriteLine("Please Press Any Key to Close!");
        Console.ReadKey();
    }


}

public class StringDuplicationProcessor
{
    protected List<string> result { get; } = new List<string>();
    public virtual List<string> Process(List<string> words)
    {
        foreach (string word in words)
        {
            char? duplicateChar = FindFirstDuplicateCharacter(word);

            if (duplicateChar.HasValue)
            {
                int indexOfDuplicate = word.IndexOf(duplicateChar.Value);
                string substringUntilDuplicate = word.Substring(0, indexOfDuplicate + 1);
                result.Add(substringUntilDuplicate);
                Console.WriteLine($"Original word: {word}");
                Console.WriteLine($"Substring until first duplicate character '{duplicateChar}': {substringUntilDuplicate}\n");
            }
            else
            {
                Console.WriteLine($"No duplicate character found in '{word}'\n");
            }
        }

        return result;
    }

    protected char? FindFirstDuplicateCharacter(string word)
    {
        HashSet<char> seenChars = new HashSet<char>();

        foreach (char c in word)
        {
            if (!seenChars.Add(c))
            {
                return c; // First duplicate character found
            }
        }

        return null; // No duplicate character found
    }
}

public class StringDuplicationTrimmingProcessor : StringDuplicationProcessor
{

    public override List<string> Process(List<string> words)
    {
        foreach (string word in words)
        {
            char? duplicateChar = FindFirstDuplicateCharacter(word);

            if (duplicateChar.HasValue)
            {
                int indexOfDuplicate = word.IndexOf(duplicateChar.Value);
                string substringUntilDuplicate = word.Substring(0, indexOfDuplicate + 1);
                result.Add(substringUntilDuplicate);
                Console.WriteLine($"Original word: {word}");
                Console.WriteLine($"Substring until first duplicate character '{duplicateChar}': {substringUntilDuplicate}\n");
            }
            else
            {
                Console.WriteLine($"No duplicate character found in '{word}'\n");
            }
        }

        return result;
    }
}

public class StringDuplicationToUppercaseProcessor : StringDuplicationProcessor
{
    public override List<string> Process(List<string> input)
    {
        return input;
    }
}
