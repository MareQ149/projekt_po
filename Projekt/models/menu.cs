/// <summary>
/// Reprezentuje Menu
/// </summary>
public class Menu
{
    /// <summary>
    /// Pole menu
    /// </summary>
    public List<Pizza> menu { get; private set; }

    /// <summary>
    /// Tworzy instancje klasy  <see cref="Menu"/>
    /// </summary>
    public Menu()
    {
        menu = new List<Pizza>();
    }

    /// <summary>
    /// Wyswietla menu
    /// </summary>
    public void DisplayMenu()
    {
        foreach (var item in menu)
        {
            string skladniki = string.Join(", ", item.ingredients.Select(i => i.Name));
            Console.WriteLine($"Nazwa: {item.name}, rozmiar: {item.size}, sk³ad: {skladniki}");
        }
    }


    /// <summary>
    /// Dodaje pizze do menu
    /// </summary>
    /// <param name="pizza">Pizza</param>
    public void AddPizza(Pizza pizza)
    {
        menu.Add(pizza);
    }
}