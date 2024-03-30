namespace CookiesRecipeApp.Recipes.Ingredients;

public abstract class Flour : Ingredient
{
    public override string PreparationInstructions() => $"Seive. {base.PreparationInstructions()}";
}
