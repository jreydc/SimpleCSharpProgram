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
    public static string RecipesToString(this Recipe Recipe)
    {
        var steps = new List<string>();
        foreach (var ingredient in Recipe.Ingredients)
        {
            steps.Add($"{ingredient.Name}. {ingredient.PreparationInstructions()}");
        }

        return string.Join(Environment.NewLine, steps );
    }
}
