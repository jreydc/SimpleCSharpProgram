using CookieCookbook.Recipes;
using CookieCookbook.Recipes.Ingredients;
using CookieCookbook.ExtensionMethods;

namespace CookieCookbook
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Cookie Cookbook Project");

            var cookiesRecipesApp = new CookiesRecipeApp(
                new RecipesRepository(),
                new RecipesConsoleUserInteraction()
                );
            cookiesRecipesApp.Run("recipes.txt");

        }
    }

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

            //_recipesUserInteraction.PromptToCreateRecipe();

            //var ingredients = _recipesUserInteraction.ReadIngredientsFromUser();

            //if(ingredients.Count > 0)
            //{
            //    var recipes = new Recipe(ingredients);
            //    allRecipes.Add(recipes);
            //    _recipesRepository.Write(filePath, allRecipes);
            //    _recipesUserInteraction.ShowMessage(
            //        "Recipe Added." +
            //        recipes.ToString()
            //        );
            //}
            //else
            //{
            //    _recipesUserInteraction.ShowMessage(
            //        "No Ingredients have been selected." +
            //        "Recipe will not be saved."
            //        );

            //}

            _recipesUserInteraction.Exit();
        }
    }

    public interface IRecipesUserInteraction
    {
        void ShowMessage(string message);
        void Exit();
        void PrintExistingRecipes(IEnumerable<Recipe> allRecipes);
    }

    public interface IRecipesRepository
    {
        List<Recipe> Read(string filePath);
    }

    public class RecipesConsoleUserInteraction : IRecipesUserInteraction 
    {

        public void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }

        public void Exit()
        {
            Console.WriteLine("Please Press Any key to Close.");
            Console.ReadKey();
        }

        public void PrintExistingRecipes(IEnumerable<Recipe> allRecipes)
        {
            if (allRecipes.Count() > 0)
            {
                Console.WriteLine("Existing recipes are: " + Environment.NewLine);

                var recipeIndex = 1;
                foreach(var recipe in allRecipes)
                {
                    Console.WriteLine($"{recipeIndex}");
                    Console.WriteLine(recipe.RecipesToString());
                    recipeIndex++;
                    Console.WriteLine();
                }
            }
        }
    }

    public class RecipesRepository : IRecipesRepository
    {
        public List<Recipe> Read(string filePath)
        {
            return new List<Recipe>
            {
                new Recipe(new List<Ingredient>
                    {
                        new WheatFlour(),
                        new Butter(),
                        new Sugar()
                    }),

                new Recipe(new List<Ingredient>
                    {
                        new CocoaPowder(),
                        new CoconutFlour(),
                        new Cinnamon()
                    })
            };
        }
    }
}
