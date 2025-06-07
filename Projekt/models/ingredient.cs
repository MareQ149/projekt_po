/// <summary>
/// Reprezentuje sk�adnik z nazw� i cen�.
/// </summary>
public class Ingredient
{  
    public static List<Ingredient> allIngredients = new List<Ingredient>();
    /// <summary>
    /// Nazwa sk�adnika.
    /// </summary>
    public string Name { get; private set; }

    /// <summary>
    /// Cena sk�adnika.
    /// </summary>
    public double Price { get; private set; }

    /// <summary>
    /// Inicjalizuje now� instancj� klasy <see cref="Ingredient"/>.
    /// </summary>
    /// <param name="ingredientName">Nazwa sk�adnika.</param>
    /// <param name="ingredientPrice">Cena sk�adnika.</param>
    public Ingredient(string ingredientName, double ingredientPrice)
    {
        Name = ingredientName;
        Price = ingredientPrice;

        allIngredients.Add(this);
    }
}