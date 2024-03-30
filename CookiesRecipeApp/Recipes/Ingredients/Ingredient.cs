namespace CookiesRecipeApp.Recipes.Ingredients;

public abstract class Ingredient
{
    public abstract int ID { get; }
    public abstract string Name { get; }
    public virtual string PreparationInstructions() => "Add to other ingredients";
}
