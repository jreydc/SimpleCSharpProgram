using System.Drawing;

namespace CookieCookbook.Recipes.Ingredients;

public abstract class Ingredient
{
    public abstract int ID { get; }
    public abstract string Name { get; }
    public virtual string PreparationInstructions() => "Add to other ingredients";
}

public class CocoaPowder : Ingredient
{
    public override int ID => 8;
    public override string Name => "Cocoa Powder";
}

public class Sugar : Ingredient
{
    public override int ID => 5;
    public override string Name => "Sugar";
}

public class Butter : Ingredient
{
    public override int ID => 3;
    public override string Name => "Butter";
    public override string PreparationInstructions() => $"Melt on low heat. {base.PreparationInstructions()}";
}

public class Chocolate : Ingredient
{
    public override int ID => 4;
    public override string Name => "Chocolate";
    public override string PreparationInstructions() => $"Melt on water bath. {base.PreparationInstructions()}";
}

public abstract class Spice : Ingredient
{
    public override string PreparationInstructions() => $"Take half a teaspoon. {base.PreparationInstructions()}";
}

public class Cardamon : Spice
{
    public override int ID => 6;
    public override string Name => "Cardamon";
}

public class Cinnamon : Spice
{
    public override int ID => 7;
    public override string Name => "Cinnamon";
}

public abstract class Flour : Ingredient
{
    public override string PreparationInstructions() => $"Seive. {base.PreparationInstructions()}";
}

public class CoconutFlour : Flour
{
    public override int ID => 2;
    public override string Name => "Coconut Flour";
}

public class WheatFlour : Flour
{
    public override int ID => 1;
    public override string Name => "Wheat Flour";
}