/// <summary>
/// Reprezentuje Menu
/// </summary>
public class Menu
{
    /// <summary>
    /// Gets the menu.
    /// </summary>
    /// <value>
    /// The menu.
    /// </value>
    public List<Pizza> menu { get; private set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Menu"/> class.
    /// </summary>
    public Menu()
    {
        menu = new List<Pizza>();
    }

    /// <summary>
    /// Displays the menu.
    /// </summary>
    public void DisplayMenu()
    {
        foreach (var item in menu)
        {
            Console.WriteLine(item);
        }
    }

    /// <summary>
    /// Adds the pizza to menu.
    /// </summary>
    /// <param name="pizza">The pizza.</param>
    public void AddPizza(Pizza pizza)
    {
        menu.Add(pizza);
    }
}