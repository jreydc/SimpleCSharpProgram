using CookieCookbook.Recipes;

namespace CookieCookbook.App;

public interface IRecipesRepository
{
    List<Recipe> Read(string filePath);
    void Write(string filePath, List<Recipe> allRecipes);
}
