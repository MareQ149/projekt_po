/// <summary>
/// Główny program
/// </summary>
public class Program
{
    static void Main()
    {
        var cheese = new Ingredient("Ser", 5.0);
        var tomato = new Ingredient("Pomidor", 3.0);
        var salami = new Ingredient("Salami", 6.0);
        var olives = new Ingredient("Oliwki", 4.0);

        var margherita = new Pizza("Margherita", new List<Ingredient> { cheese, tomato }, PizzaSize.MEDIUM, true);
        var pepperoni = new Pizza("Pepperoni", new List<Ingredient> { cheese, salami }, PizzaSize.LARGE, true);

        var menu = new Menu();
        menu.AddPizza(margherita);
        menu.AddPizza(pepperoni);
        var orderQueue = new OrderQueue(new List<Order>());


        int licznik = 1;
        int choice = Interface.Select();
        if (choice == 0)
        {
            choice = Interface.Select();
        }
        else if (choice == 1)
        {
            while (true)
            {
                Interface.UserInterface();
                int choice2 = int.Parse(Console.ReadLine()!);
                switch (choice2)
                {
                    case 1:
                        menu.DisplayMenu();
                        break;
                    case 2:
                        Interface.CreateOrder(menu, ref licznik);
                        break;
                    case 3:
                        Interface.ViewCurrentOrders(orderQueue);
                        break;
                    case 4:
                        Interface.CancelOrderById(orderQueue);
                        break;
                    case 0:
                        Interface.Select();
                        break;
                    default:
                        Console.WriteLine("Nieprawidłowy wybór. Proszę spróbować ponownie.");
                        break;
                }
            }
        }
    }
}
