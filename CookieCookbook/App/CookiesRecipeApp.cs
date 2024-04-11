using CookieCookbook.Recipes;
using CookieCookbook.ExtensionMethods;

namespace CookieCookbook.App;

public class CookiesRecipeApp
{
    private readonly IRecipesRepository _recipesRepository;
    private readonly IRecipesUserInteraction _recipesUserInteraction;

    public CookiesRecipeApp(
        IRecipesRepository recipesRepository,
        IRecipesUserInteraction recipesUserInteraction
        )
    {
        _recipesRepository = recipesRepository;
        _recipesUserInteraction = recipesUserInteraction;
    }

    public void Run(string filePath)
    {
        var allRecipes = _recipesRepository.Read(filePath);
        _recipesUserInteraction.PrintExistingRecipes(allRecipes);

        _recipesUserInteraction.PromptToCreateRecipe();

        var ingredients = _recipesUserInteraction.ReadIngredientsFromUser();

        if (ingredients.Count() > 0)
        {
            var recipes = new Recipe(ingredients);
            allRecipes.Add(recipes);
            _recipesRepository.Write(filePath, allRecipes);

            _recipesUserInteraction.ShowMessage(
                "Recipe Added." +
                Environment.NewLine +
                recipes.RecipesToString()
                );
        }
        else
        {
            _recipesUserInteraction.ShowMessage(
                "No Ingredients have been selected." +
                "Recipe will not be saved."
                );

        }

        _recipesUserInteraction.Exit();
    }
}
