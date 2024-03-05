namespace OOP_Polymorphism_Pizza;

public class Pizza
{
    private List<Ingredient> _ingredients = new List<Ingredient>();


}

public class Ingredient
{
    public virtual string Name { get; } = "Some Ingredient";
}

public class Cheddar : Ingredient
{
    public override string Name => "Cheddar";
    public int AgedForMonths { get; set; }
}

public class TomatoSauce : Ingredient
{
    public override string Name => "Tomato Sauce";
    public int TomatoesIn100Grams { get; set; }
}

public class Mozzarella : Ingredient
{
    public override string Name => "Mozzarella";
    public bool IsLight { get; set; }
}