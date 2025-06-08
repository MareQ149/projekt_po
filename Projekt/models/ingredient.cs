/// <summary>
/// Reprezentuje sk³adnik z nazw¹ i cen¹.
/// </summary>
public class Ingredient
{  
    public static List<Ingredient> allIngredients = new List<Ingredient>();
    /// <summary>
    /// Nazwa sk³adnika.
    /// </summary>
    public string Name { get; private set; }

    /// <summary>
    /// Cena sk³adnika.
    /// </summary>
    public double Price { get; private set; }

    /// <summary>
    /// Tworzy instancje klasy <see cref="Ingredient"/> 
    /// </summary>
    /// <param name="ingredientName">Nazwa sk³adnika</param>
    /// <param name="ingredientPrice">Cena sk³adnika</param>
    /// <exception cref="System.ArgumentException">ingredientName - Nazwa sk³adnika nie mo¿e byæ pusta</exception>
    public Ingredient(string ingredientName, double ingredientPrice)
    {
        

        Name = ingredientName;
        Price = ingredientPrice;

        allIngredients.Add(this);
    }
}