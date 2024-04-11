namespace CookieCookbook.Repositories;

public interface IStringRepository
{
    List<string> Read(string filePath);
    void Write(string filePath, List<string> strings);

}
