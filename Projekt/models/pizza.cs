class Pizza { 
    public string name { get; private set; }
    public List<Ingredient> ingredients { get; private set; }
    public PizzaSize size { get; private set; }
    public bool addToMenu { get; private set; }

    public Pizza(string pizzaName, List<Ingredient> pizzaIngredients, PizzaSize pizzaSize, bool addToMenu)
    {
        if (string.IsNullOrWhiteSpace(pizzaName))
        {
            throw new ArgumentException("Pizza musi mieæ nazwê!", nameof(pizzaName));

        }

        if (pizzaIngredients is null || pizzaIngredients.Count == 0)
        {
            throw new ArgumentNullException(nameof(pizzaIngredients), "Pizza musi siê sk³adaæ z conajmniej 1 sk³adnika!!");
        }


        this.name = pizzaName;
        ingredients = pizzaIngredients;
        size = pizzaSize;
        this.addToMenu = addToMenu;
        
    }

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