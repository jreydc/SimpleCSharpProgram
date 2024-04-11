using CookieCookbook.Recipes;

namespace CookieCookbook
{
    public class StringTextualRepository : IStringRepository
    {
        private static readonly string Separator = Environment.NewLine;
        //public void Write(string filePath, List<Recipe> allRecipes)
        //{
        //    File.WriteAllText(filePath, string.Join(Separator, allRecipes));
        //}

        public List<string> Read(string filePath)
        {
            if (File.Exists(filePath))
            {
                var fileContents = File.ReadAllText(filePath);
                return fileContents.Split(Separator).ToList();
            }
            
            return new List<string>();
        }

        public void Write(string filePath, List<string> strings)
        {
            File.WriteAllText(filePath, string.Join(Separator, strings));
        }
    }
}
