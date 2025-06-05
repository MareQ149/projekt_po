class Menu
{
    public List<Pizza> menu { get; private set; }

    public Menu()
    {
        menu = new List<Pizza>();
    }

    public void DisplayMenu()
    {
        foreach (var item in menu)
        {
            Console.WriteLine(item);
        }
    }

    public void AddPizza(Pizza pizza)
    {
        menu.Add(pizza);
    }
}