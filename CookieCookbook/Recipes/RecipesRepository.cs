using CookieCookbook.Recipes.Ingredients;
using CookieCookbook.ExtensionMethods;
using CookieCookbook.Repositories;
using CookieCookbook.App;

namespace CookieCookbook.Recipes;

public class RecipesRepository : IRecipesRepository
{
    private readonly IStringRepository _stringRepository;
    private readonly IIngredientsRegister _ingredientsRegister;

    public RecipesRepository(
        IStringRepository stringRepository,
        IIngredientsRegister ingredientsRegister)
    {
        _stringRepository = stringRepository;
        _ingredientsRegister = ingredientsRegister;
    }

    public List<Recipe> Read(string filePath)
    {
        List<string> recipesFromFile = _stringRepository.Read(filePath);
        var recipes = new List<Recipe>();

        foreach (var recipeFromFile in recipesFromFile)
        {
            var recipe = recipeFromFile.RecipeFromFileToStrings(_ingredientsRegister);
            recipes.Add(recipe);
        }

        return recipes;
    }

    public void Write(string filePath, List<Recipe> allRecipes)
    {
        var recipeAsStrings = allRecipes.RecipesToListOfStrings(",");
        _stringRepository.Write(filePath, recipeAsStrings);
    }
}
