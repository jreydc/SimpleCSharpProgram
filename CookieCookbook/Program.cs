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
                new RecipesRepository(
                    new StringTextualRepository(),
                    new IngredientsRegister()
                    ),
                new RecipesConsoleUserInteraction(
                    new IngredientsRegister()
                    )
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

            _recipesUserInteraction.PromptToCreateRecipe();

            var ingredients = _recipesUserInteraction.ReadIngredientsFromUser();

            if (ingredients.Count() > 0)
            {
                var recipes = new Recipe(ingredients);
                allRecipes.Add(recipes);
                _recipesRepository.Write(filePath, allRecipes);
                
                _recipesUserInteraction.ShowMessage(
                    "Recipe Added." +
                    Environment.NewLine +
                    recipes.RecipesToString()
                    );
            }
            else
            {
                _recipesUserInteraction.ShowMessage(
                    "No Ingredients have been selected." +
                    "Recipe will not be saved."
                    );

            }

            _recipesUserInteraction.Exit();
        }
    }

    public interface IRecipesUserInteraction
    {
        void ShowMessage(string message);
        void Exit();
        void PrintExistingRecipes(IEnumerable<Recipe> allRecipes);
        void PromptToCreateRecipe();
        IEnumerable<Ingredient> ReadIngredientsFromUser();
    }

    public interface IRecipesRepository
    {
        List<Recipe> Read(string filePath);
        void Write(string filePath, List<Recipe> allRecipes);
    }

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
                foreach(var recipe in allRecipes)
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
            foreach(var ingredient in _ingredientsRegister.All)
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

                if (int.TryParse(userInput,out int ingredientID))
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

    public interface IStringRepository
    {
        List<string> Read(string filePath);
        void Write(string filePath, List<string> strings);

    }

    public class RecipesRepository : IRecipesRepository
    {
        private readonly IStringRepository _stringRepository;
        private readonly IIngredientsRegister _ingredientsRegister;

        public RecipesRepository(
            IStringRepository stringRepository,
            IIngredientsRegister ingredientsRegister)
        {
            _stringRepository = stringRepository;
            _ingredientsRegister = ingredientsRegister;
        }

        public List<Recipe> Read(string filePath)
        {
            List<string> recipesFromFile = _stringRepository.Read(filePath);
            var recipes = new List<Recipe>();

            foreach (var recipeFromFile in recipesFromFile)
            {
                var recipe = recipeFromFile.RecipeFromFileToStrings(_ingredientsRegister);
                recipes.Add(recipe);
            }

            return recipes;
        }

        public void Write(string filePath, List<Recipe> allRecipes)
        {
            var recipeAsStrings = allRecipes.RecipesToListOfStrings(",");
            _stringRepository.Write(filePath, recipeAsStrings);
        }
    }
}
