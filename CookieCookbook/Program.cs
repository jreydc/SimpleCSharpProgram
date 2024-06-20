using CookieCookbook.Recipes;
using CookieCookbook.Recipes.Ingredients;
using CookieCookbook.Repositories;
using CookieCookbook.Data;
using CookieCookbook.App;

namespace CookieCookbook;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Cookie Cookbook Project");

        const FileFormat Format = FileFormat.TXT; //This dictates the format of the repository whether it is JSON or TXT fileformat

        IStringRepository stringsRepository = Format == FileFormat.JSON ? new StringJsonRepository() : new StringTextualRepository() ;

        string FileName = "recipes";
        var fileMetadata = new FileMetadata(FileName, Format);

        var ingredientRegister = new IngredientsRegister();

        var cookiesRecipesApp = new CookiesRecipeApp(
            new RecipesRepository(
                stringsRepository,
                ingredientRegister
                ),
            new RecipesConsoleUserInteraction(
                ingredientRegister
                )
            );
        cookiesRecipesApp.Run(fileMetadata.ToPath());

    }
}
