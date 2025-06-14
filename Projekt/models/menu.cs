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
        int licznik = 1;
        Console.WriteLine("=== MENU PIZZY ===");
        foreach (var item in menu)
        {
            string skladniki = string.Join(", ", item.ingredients.Select(i => i.Name));

            Console.WriteLine($"Id: {licznik}, Nazwa: {item.name}, rozmiar: {item.size}, sk�ad: {skladniki}, cena: {item.GetPrice()}");
            licznik++;
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