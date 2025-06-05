class Ingredient { 
    public string name { get; private set; }
    public double price { get; private set; }

    public Ingredient(string ingredientName, double ingredientPrice)
    {
        name = ingredientName;
        price = ingredientPrice;
    }
}