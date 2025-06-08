public class Program
{
    static void Main()
    {
    StartProgram: // etykieta dla restartu programu

        var cheese = new Ingredient("Ser", 5.0);
        var tomato = new Ingredient("Pomidor", 3.0);
        var salami = new Ingredient("Salami", 6.0);
        var olives = new Ingredient("Oliwki", 4.0);

        var margherita = new Pizza("Margherita", new List<Ingredient> { cheese, tomato }, PizzaSize.MEDIUM, true);
        var pepperoni = new Pizza("Pepperoni", new List<Ingredient> { cheese, salami }, PizzaSize.LARGE, true);

        var menu = new Menu();
        menu.AddPizza(margherita);
        menu.AddPizza(pepperoni);
        var queue = new OrderQueue(new List<Order>());

        int licznik = 1;
        int choice = Interface.Select();

        if (choice == 1)
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
                        Interface.CreateOrder(menu, ref licznik, queue);
                        break;
                    case 3:
                        Interface.ViewCurrentOrders(queue);
                        break;
                    case 4:
                        Interface.CancelOrderById(queue);
                        break;
                    case 5:
                        goto StartProgram;
                    case 0:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Nieprawidłowy wybór. Proszę spróbować ponownie.");
                        break;
                }
            }
        }
        else if (choice == 2)
        {
            while (true)
            {
                Interface.WorkerInterface();
                int choice2 = int.Parse(Console.ReadLine()!);
                switch (choice2)
                {
                    case 1:
                        menu.DisplayMenu();
                        break;
                    case 2:
                        Interface.ViewCurrentOrders(queue);
                        break;
                    case 3:
                        Interface.ChangeOrderStatusById(queue);
                        break;
                    case 4:
                        Interface.AddPizzaToMenu(menu);
                        break;
                    case 5:
                        Interface.CreateIngredient();
                        break;
                    case 6:
                        goto StartProgram;
                    case 0:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Nieprawidłowy wybór. Proszę spróbować ponownie.");
                        break;
                }
            }
        }
        else
        {
            goto StartProgram;
        }
    }
}
