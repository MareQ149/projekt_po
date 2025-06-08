/// <summary>
/// Reprezentuje listę zamówień
/// </summary>
public class OrderQueue
{
    /// <summary>
    /// lista zamówień
    /// </summary>
    public List<Order> orders { get; private set; }
    /// <summary>
    /// Tworzy instancję klasy <see cref="OrderQueue"/> class.
    /// </summary>
    /// <param name="orders">zamówienia</param>
    public OrderQueue(List<Order> orders)
    {
        this.orders = orders;
    }

    /// <summary>
    /// Dodaje zamoienie do kolejki
    /// </summary>
    /// <param name="order">Zamowienie.</param>
    public void AddToQueue(Order order)
    {
        orders.Add(order);
    }
    /// <summary>
    /// Wyświetla listę zamówień
    /// </summary>
    public void DisplayQueue()
    {
        if (orders.Count == 0)
        {
            Console.WriteLine("Brak zamówień w kolejce.");
            return;
        }
        Console.WriteLine("=== Lista zamówień ===");
        foreach (var item in orders)
        {
            Console.WriteLine($"Numer zamówienia: {item.id}, Nazwa zamówienia: {item.orderName}, Przewidywany czas zamówienia{item.OrderTime}");
        }
    }
}