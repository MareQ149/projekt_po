/// <summary>
/// Reprezentuje pizze z nazw�, rozmiarem, list� sk�adnik�w oraz czy ma zosta� dodana do menu
/// </summary>
public class Pizza {
    public static List<Pizza> allPizzas = new List<Pizza>();
    /// <summary>
    /// Nazwa pizzy
    /// </summary>
    public string name { get; private set; }
    /// <summary>
    /// Sk�adniki pizzy
    /// </summary>
    public List<Ingredient> ingredients { get; private set; }
    /// <summary>
    /// Rozmiar pizzy
    /// </summary>
    public PizzaSize size { get; private set; }
    /// <summary>
    /// Czy doda� pizze do menu
    /// </summary>
    public bool addToMenu { get; private set; }

    /// <summary>
    /// Tworzy instancje klasy <see cref="Pizza"/>
    /// </summary>
    /// <param name="pizzaName">Nazwa pizzy</param>
    /// <param name="pizzaIngredients">Sk�adniki pizzy</param>
    /// <param name="pizzaSize">Rozmiar pizzy</param>
    /// <param name="addToMenu">je�li true - mo�na dodac do menu</param>
    
    public Pizza(string pizzaName, List<Ingredient> pizzaIngredients, PizzaSize pizzaSize, bool addToMenu)
    {
        

        this.name = pizzaName;
        ingredients = pizzaIngredients;
        size = pizzaSize;
        this.addToMenu = addToMenu;

        allPizzas.Add(this);

    }

    /// <summary>
    /// Zwraca cene pizzy.
    /// </summary>
    public double GetPrice()
    {
        double price = 0;
        foreach (var item in ingredients)
        {
            price += item.Price;
        }
        if(this.size == PizzaSize.LARGE) { price += 20; }
        else if(this.size == PizzaSize.MEDIUM) { price += 15; }
        else { price += 10; }

        return price;
    }
}