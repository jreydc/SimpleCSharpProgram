
using CookiesRecipeApp.Recipes;
using CookiesRecipeApp.Recipes.Ingredients;



Console.WriteLine("Cookies Recipe Application!");
var cookiesRecipeApp = new CookiesRecipeApp(
    new RecipesRepository(),
    new RecipesConsoleUserInteraction()
    );
cookiesRecipeApp.Run();

public class CookiesRecipeApp
{
    private readonly IRecipesRepository _recipesRepository;
    private readonly IRecipesConsoleUserInteraction _recipesUserInteraction;

    public CookiesRecipeApp(
        RecipesRepository recipesRepository,
        RecipesConsoleUserInteraction recipesUserInteraction
        )
    {
        _recipesRepository = recipesRepository;
        _recipesUserInteraction = recipesUserInteraction;
    }
    public void Run()
    {
        var allRecipes = _recipesRepository.Read(filepath);
        _recipesUserInteraction.PrintAllExistingIngredients(allRecipes);

        _recipesUserInteraction.PromptToCreateNewRecipe();

        var ingredients = _recipesUserInteraction.ReadIngredientsFromUser();

        if (ingredients.Count > 0)
        {
            var recipe = new Recipe();
            allRecipes.Add(recipe);
            _recipesRepository.Write(allRecipes, filepath);

            _recipesUserInteraction.ShowMessage("Recipe created successfully!");
            _recipesUserInteraction.ShowMessage(recipe.ToString());
        }
        else
        {
            _recipesUserInteraction.ShowMessage("No ingredients entered. Please try again.");
        }

        _recipesUserInteraction.Exit();
    }
}

public interface IRecipesConsoleUserInteraction
{
    void Exit();
    void ShowMessage(string message);
}

public class RecipesConsoleUserInteraction : IRecipesConsoleUserInteraction
{
    public void Exit()
    {

        Console.WriteLine("Please press any key to exit...");
        Console.ReadKey();
    }

    public void ShowMessage(string message)
    {
        Console.WriteLine(message);
    }
}

public interface IRecipesRepository
{
    List<CookiesRecipeApp.Recipes.Ingredients.Recipe> Read(object filepath);
}

public class RecipesRepository : IRecipesRepository
{
}