using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CookieCookbook.Recipes.Ingredients;

namespace CookieCookbook.Recipes;

public class Recipe
{
    //public List<Ingredient> Ingredients { get;} change to IEnumerable - interface inheriting all the collections 
    public IEnumerable<Ingredient> Ingredients { get; } 
    public Recipe(IEnumerable<Ingredient> ingredients) => Ingredients = ingredients;

}
