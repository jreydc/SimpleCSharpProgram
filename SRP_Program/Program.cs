using SRP_Program.DataAccess;

var stopwatch = Stopwatch.StartNew();


Console.WriteLine("Single Responsibility Principle Program!");

var names = new Names();
var path = new NamesFilePathBuilder().BuildFilePath();
var stringTextualRepository = new NamesRepository();

if (File.Exists(path))
{
    Console.WriteLine("Names file already exists. Loading names...");
    var stringsFromFile = stringTextualRepository.Read(path);
    names.AddNames(stringsFromFile);
}
else
{
    Console.WriteLine("Names file does not exist. Creating names...");

    names.AddName("John");
    names.AddName("not a valid Name");
    names.AddName("Claire");
    names.AddName("123 definitely not a valid name");

    Console.WriteLine("Saving names to a file");
    stringTextualRepository.Write(path, names.All);
}
Console.WriteLine(new NamesFormatter().Format(names.All));
Console.WriteLine();
Console.WriteLine("Please Press Any Key to Close.");
Console.ReadKey();

