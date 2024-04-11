using CookieCookbook.Recipes;
using CookieCookbook.Recipes.Ingredients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookieCookbook.ExtensionMethods;

public static class Extensions
{
    public static string RecipesToString(this Recipe Recipe, string Separator = "\n")
    {
        var steps = new List<string>();
        foreach (var ingredient in Recipe.Ingredients)
        {
            steps.Add($"{ingredient.Name}. {ingredient.PreparationInstructions()}");
        }

        return string.Join(Separator, steps );
    }

    public static string RecipesIDToString(this Recipe Recipe, string Separator = "\n")
    {
        var steps = new List<string>();
        foreach (var ingredient in Recipe.Ingredients)
        {
            steps.Add($"{ingredient.ID}. {ingredient.Name}");
        }

        return string.Join(Separator, steps);
    }

    public static string IngredientsIDToString(this Ingredient Ingredient, string Separator = "\n")
    {
        return string.Join(Separator, $"{Ingredient.ID}. {Ingredient.Name}");
    }

    public static List<string> RecipesToListOfStrings(this List<Recipe> AllRecipes, string Separator = "\n") 
    { 
        var recipeAsStrings = new List<string>();
        foreach (var recipe in  AllRecipes)
        {
            var allIDs = new List<int>();
            foreach (var ingredients in recipe.Ingredients)
            {
                allIDs.Add(ingredients.ID);
            }
            recipeAsStrings.Add(string.Join(Separator, allIDs));
        }
        return recipeAsStrings;    
    }

    public static Recipe RecipeFromFileToStrings(this string recipeFromFile, IIngredientsRegister ingredientRegister)
    {
        var textualIDs = recipeFromFile.Split(",");
        var ingredients = new List<Ingredient>();

        foreach(var textualID in textualIDs)
        {
            var id = int.Parse(textualID);
            var ingredient = ingredientRegister.GetByID(id);
            ingredients.Add(ingredient);
        }

        return new Recipe(ingredients);
    }
}
