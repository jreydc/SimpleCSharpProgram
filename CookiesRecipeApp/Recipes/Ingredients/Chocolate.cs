namespace CookiesRecipeApp.Recipes.Ingredients;

public class Chocolate : Ingredient
{
    public override int ID => 4;
    public override string Name => "Chocolate";
    public override string PreparationInstructions() => $"Melt on water bath. {base.PreparationInstructions()}";
}
