using CookieCookbook.Recipes.Ingredients;

namespace CookieCookbook
{
    public interface IIngredientsRegister
    {
        IEnumerable<Ingredient> All { get; }

        Ingredient? GetByID(int ingredientID);
    }

    public class IngredientsRegister : IIngredientsRegister
    {
        public IEnumerable<Ingredient> All { get; } = new List<Ingredient>()
        {
            new WheatFlour(),
            new CoconutFlour(),
            new Butter(),
            new Chocolate(),
            new Sugar(),
            new Cardamon(),
            new Cinnamon(),
            new CocoaPowder()
        };

        public Ingredient? GetByID(int ingredientID)
        {
            foreach (var ingredient in All)
            {
                if (ingredient.ID == ingredientID) return ingredient;
            }

            return null;
        }
    }
}
