using System.Text.Json;

namespace CookieCookbook.Repositories;

public class StringJsonRepository : StringsRepository
{
    protected override List<string> TextToStrings(string fileContents) => JsonSerializer.Deserialize<List<string>>(fileContents);

    protected override string StringsToText(List<string> strings) => JsonSerializer.Serialize(strings);

}
