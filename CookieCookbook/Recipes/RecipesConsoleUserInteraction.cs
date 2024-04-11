using CookieCookbook.Recipes.Ingredients;
using CookieCookbook.ExtensionMethods;
using CookieCookbook.App;

namespace CookieCookbook.Recipes;

public class RecipesConsoleUserInteraction : IRecipesUserInteraction
{
    private readonly IIngredientsRegister _ingredientsRegister;

    public RecipesConsoleUserInteraction(IIngredientsRegister ingredientsRegister)
    {
        _ingredientsRegister = ingredientsRegister;
    }

    public void ShowMessage(string message)
    {
        Console.WriteLine(message);
    }

    public void Exit()
    {
        Console.WriteLine("Please Press Any key to Close.");
        Console.ReadKey();
    }

    public void PrintExistingRecipes(IEnumerable<Recipe> allRecipes)//Printing the Existing Recipes
    {
        if (allRecipes.Count() > 0)
        {
            Console.WriteLine("Existing recipes are: " + Environment.NewLine);

            var recipeIndex = 1;
            foreach (var recipe in allRecipes)
            {
                Console.WriteLine($"{recipeIndex}");
                Console.WriteLine(recipe.RecipesToString());
                recipeIndex++;
                Console.WriteLine();
            }
        }
    }

    public void PromptToCreateRecipe()
    {
        Console.WriteLine(
            "Create a new cookie recipe! " +
            "Available ingredients are: " +
            Environment.NewLine
            );

        //Printing Available Ingredients from IngredientRegister
        foreach (var ingredient in _ingredientsRegister.All)
        {
            Console.WriteLine(ingredient.IngredientsIDToString());
        }
    }

    public IEnumerable<Ingredient> ReadIngredientsFromUser()
    {
        bool shallStop = false;
        var ingredients = new List<Ingredient>();

        while (!shallStop)
        {
            Console.WriteLine(
                "Add an ingredient by its ID, " +
                "or Type anything else if finished."
                );

            var userInput = Console.ReadLine();

            if (int.TryParse(userInput, out int ingredientID))
            {
                var selectedIngredient = _ingredientsRegister.GetByID(ingredientID);
                if (selectedIngredient != null)
                {
                    ingredients.Add(selectedIngredient);
                }
            }
            else
            {
                shallStop = true;
            }
        }

        return ingredients;
    }
}
