/// <summary>
/// Reprezentuje pizze z nazw�, rozmiarem, list� sk�adnik�w oraz czy ma zosta� dodana do menu
/// </summary>
class Pizza {
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
    /// Initializes a new instance of the <see cref="Pizza"/> class.
    /// </summary>
    /// <param name="pizzaName">Name of the pizza.</param>
    /// <param name="pizzaIngredients">The pizza ingredients.</param>
    /// <param name="pizzaSize">Size of the pizza.</param>
    /// <param name="addToMenu">if set to <c>true</c> [add to menu].</param>
    /// <exception cref="System.ArgumentException">Pizza musi mie� nazw�! - pizzaName</exception>
    /// <exception cref="System.ArgumentNullException">pizzaIngredients - Pizza musi si� sk�ada� z conajmniej 1 sk�adnika!!</exception>
    public Pizza(string pizzaName, List<Ingredient> pizzaIngredients, PizzaSize pizzaSize, bool addToMenu)
    {
        if (string.IsNullOrWhiteSpace(pizzaName))
        {
            throw new ArgumentException("Pizza musi mie� nazw�!", nameof(pizzaName));

        }

        if (pizzaIngredients is null || pizzaIngredients.Count == 0)
        {
            throw new ArgumentNullException(nameof(pizzaIngredients), "Pizza musi si� sk�ada� z conajmniej 1 sk�adnika!!");
        }


        this.name = pizzaName;
        ingredients = pizzaIngredients;
        size = pizzaSize;
        this.addToMenu = addToMenu;
        
    }

    /// <summary>
    /// Gets the price.
    /// </summary>
    /// <returns></returns>
    public double GetPrice()
    {
        double price = 0;
        foreach (var item in ingredients)
        {
            price += item.Price;
        }
        return price;
    }
}