/// <summary>
/// Interfejs użytkownika, który umożliwia interakcję z systemem zamówień pizzy.
/// </summary>
public class Interface {
    /// <summary>
    /// Wybor rodzaju konta użytkownika.
    /// </summary>
    public static int Select() 
    {
        Console.WriteLine("Wybierz rodzaj konta: 1 - Klient, 2 - Pracownik");
        string wybor = Console.ReadLine()!;
        if(wybor == "1")
        {
            return 1;
        }
        else if(wybor == "2")
        {
            return 2;
        }
        else
        {
            Console.WriteLine("Nieprawidłowy wybór. Spróbuj ponownie.");
            return 0;
        }
    }
    /// <summary>
    /// Interfejs użytkownika dla klienta, który umożliwia przeglądanie menu pizzy, tworzenie zamówień, przeglądanie kolejki zamówień i anulowanie zamówień.
    /// </summary>
    public static void UserInterface()
    {
        Console.WriteLine("=== MENU KLIENTA ===");
        Console.WriteLine("1. Zobacz menu pizzy");
        Console.WriteLine("2. Stwórz zamówienie");
        Console.WriteLine("3. Zobacz kolejkę zamówień");
        Console.WriteLine("4. Anuluj zamówienie");
        Console.WriteLine("5. Zmień rodzaj konta");
        Console.WriteLine("0. Wyjście");
    }
    /// <summary>
    /// Interfejs pracownika, który umożliwia przeglądanie menu pizzy, przeglądanie kolejki zamówień, zmienianie statusu zamówienia, dodawanie pizzy do menu i dodawanie składników do listy składników.
    /// </summary>
    public static void WorkerInterface()
    {
        Console.WriteLine("=== MENU PRACOWNIKA ===");
        Console.WriteLine("1. Zobacz menu pizzy");
        Console.WriteLine("2. Zobacz kolejkę zamówień");
        Console.WriteLine("3. Zmień status zamówienia (po id)");
        Console.WriteLine("4. Dodaj pizze do menu");
        Console.WriteLine("5. Dodaj składnik do listy składników");
        Console.WriteLine("6. Zmień rodzaj konta");
        Console.WriteLine("0. Wyjście");
    }
    /// <summary>
    /// Tworzenie własnej pizzy, gdzie użytkownik może wybrać nazwę, rozmiar i składniki pizzy.
    /// </summary>
    public static Pizza CreateCustomPizza()
    {
        Console.WriteLine("=== TWORZENIE WŁASNEJ PIZZY ===");
        Console.WriteLine("Podaj nazwę pizzy:");
        string pizzaName = Console.ReadLine()!;
        Console.WriteLine("=== PODAJ ROZMIAR ===");
        Console.WriteLine("Podaj rozmiar pizzy \n 1. mała \n 2. średnia \n 3. duża");
        int choice = int.Parse(Console.ReadLine()!);
        PizzaSize size = PizzaSize.SMALL;
        if (choice < 1 || choice > 3)
        {
            Console.WriteLine("Nieprawidłowy wybór. Spróbuj ponownie.");
            CreateCustomPizza();
        }
        else
        {
            if (choice == 1)
            {
                size = PizzaSize.SMALL;
            }
            else if (choice == 2)
            {
                size = PizzaSize.MEDIUM;
            }
            else
            {
                size = PizzaSize.LARGE;

            }
        }
        Console.WriteLine("Wybierz składniki:");
        List<Ingredient> ingredients = new();
        while (true)
        {
            int ingredientId = 1;
            foreach (var ingredient in Ingredient.allIngredients)
            {
                Console.WriteLine($"{ingredientId}. {ingredient.Name} - {ingredient.Price} zł");
                ingredientId++;
            }
            Console.WriteLine("Wybierz składnik (lub wpisz 0, aby zakończyć):");
            int ingredientChoice = int.Parse(Console.ReadLine()!);
            if (ingredientChoice == 0)
            {
                break; // Zakończ wybieranie składników
            }
            if (ingredientChoice < 1 || ingredientChoice > Ingredient.allIngredients.Count)
            {
                Console.WriteLine("Nieprawidłowy wybór. Spróbuj ponownie.");
                continue; // Poproś o ponowny wybór składnika
            }
            ingredients.Add(Ingredient.allIngredients[ingredientChoice - 1]); // Dodaj składnik do listy
        }
        
        Pizza customPizza = new Pizza(pizzaName, ingredients, size, false);
        // Logika dodawania pizzy do menu lub zamówienia
        Console.WriteLine($"Stworzono pizzę: {customPizza.name}, rozmiar: {customPizza.size}, skład: {string.Join(", ", customPizza.ingredients.Select(i => i.Name))}");
        return customPizza;
    }
    /// <summary>
    /// Tworzenie zamówienia, gdzie użytkownik może wybrać pizzę z menu lub stworzyć własną pizzę, a także zastosować promocję 2+1.
    /// </summary>
    /// <param name="menu">Menu pizzy</param>
    /// <param name="licznik">Id</param>
    /// <param name="queue">Kolejka zamówień</param>
    public static void CreateOrder(Menu menu, ref int licznik, OrderQueue queue)
    {
        
        Console.WriteLine("=== TWORZENIE ZAMÓWIENIA ===");
        Console.WriteLine("Czy chcesz zastosować promocję 2+1 (tylko pizzę z menu)?");
        Console.WriteLine("1. Tak");
        Console.WriteLine("2. Nie");
        string choice = Console.ReadLine()!;
        if (choice == "1")
        {
            Console.WriteLine("Wybierz 3 pizze, najtańsza będzie gratis!");
            menu.DisplayMenu();
            Console.WriteLine("Wybierz pierwszą pizzę:");
            int firstPizza = int.Parse(Console.ReadLine()!);
            if (firstPizza < 1 || firstPizza > menu.menu.Count)
            {
                Console.WriteLine("Nieprawidłowy wybór. Spróbuj ponownie.");
                CreateOrder(menu, ref licznik, queue);
                return;
            }
            Console.WriteLine("Wybierz drugą pizzę:");
            int secondPizza = int.Parse(Console.ReadLine()!);
            if (secondPizza < 1 || secondPizza > menu.menu.Count)
            {
                Console.WriteLine("Nieprawidłowy wybór. Spróbuj ponownie.");
                CreateOrder(menu, ref licznik, queue);
                return;
            }
            Console.WriteLine("Wybierz trzecią pizzę:");
            int thirdPizza = int.Parse(Console.ReadLine()!);
            if (thirdPizza < 1 || thirdPizza > menu.menu.Count)
            {
                Console.WriteLine("Nieprawidłowy wybór. Spróbuj ponownie.");
                CreateOrder(menu, ref licznik, queue);
                return;
            }
            List<Pizza> pizzas = new();
            pizzas.Add(menu.menu[firstPizza - 1]); // Zakładamy, że indeksy zaczynają się od 0
            pizzas.Add(menu.menu[secondPizza - 1]);
            pizzas.Add(menu.menu[thirdPizza - 1]);
            Console.WriteLine("Podaj nazwę zamówienia:");
            string orderName = Console.ReadLine()!;
            Order zamowienie = new Order(licznik, orderName, pizzas);
            licznik++;
            Promotion.ApplyPromo2Plus1(zamowienie);
            queue.AddToQueue(zamowienie);
            // Logika wyboru pizzy
        }
        else if (choice == "2")
        {
            List<Pizza> pizzas = new();
            while (true)
            {
                Console.WriteLine("1. Wybierz pizzę z menu:");
                Console.WriteLine("2. Stwórz własną pizzę");
                Console.WriteLine("0. Zakończ zamówienie");
                int choice2 = int.Parse(Console.ReadLine()!);
                if (choice2 == 1)
                {
                    menu.DisplayMenu();
                    Console.WriteLine("Wybierz pizzę:");
                    int pizzaChoice = int.Parse(Console.ReadLine()!);
                    if (pizzaChoice < 1 || pizzaChoice > menu.menu.Count)
                    {
                        Console.WriteLine("Nieprawidłowy wybór. Spróbuj ponownie.");
                        CreateOrder(menu, ref licznik, queue);
                        return;
                    }
                    Pizza wybranaPizza = menu.menu[pizzaChoice - 1];
                    pizzas.Add(wybranaPizza);
                }
                else if (choice2 == 2)
                {
                    pizzas.Add(CreateCustomPizza()); // Dodaj własną pizzę do zamówienia
                }
                else if (choice2 == 0)
                {
                    Console.WriteLine("Podaj nazwę zamówienia:");
                    string orderName = Console.ReadLine()!;
                    Order zamowienie = new Order(licznik, orderName, pizzas);
                    queue.AddToQueue(zamowienie);
                    licznik++;
                    Console.WriteLine("Zamówienie zakończone.");
                    break; // Zakończ zamówienie
                }
                else
                {
                    Console.WriteLine("Nieprawidłowy wybór. Spróbuj ponownie.");
                }
            }
        }
        else
        {
            Console.WriteLine("Nieprawidłowy wybór. Spróbuj ponownie.");
            CreateOrder(menu, ref licznik, queue);
        }
    }
    /// <summary>
    /// Wyświetla aktualne zamówienia w kolejce.
    /// </summary>
    /// <param name="queue">Kolejka zamówień</param>
    public static void ViewCurrentOrders(OrderQueue queue)
    {
        queue.DisplayQueue();
    }
    /// <summary>
    /// Anuluje zamówienie na podstawie jego ID.
    /// </summary>
    /// <param name="queue">Kolejka zamówień</param>
    public static void CancelOrderById(OrderQueue queue)
    {
        queue.DisplayQueue();
        Console.WriteLine("Podaj numer zamówienia do anulowania:");

        if (int.TryParse(Console.ReadLine(), out int anulowaneZamowienie))
        {
            Order? orderToCancel = queue.orders.FirstOrDefault(o => o.id == anulowaneZamowienie);

            if (orderToCancel != null)
            {
                orderToCancel.CancelOrder();
                Console.WriteLine("Zamówienie zostało anulowane.");
            }
            else
            {
                Console.WriteLine("Nie znaleziono zamówienia o podanym numerze.");
            }
        }
        else
        {
            Console.WriteLine("Niepoprawny format numeru zamówienia.");
        }

    }
    /// <summary>
    /// Zmienia status zamówienia na podstawie jego ID.
    /// </summary>
    /// <param name="queue">Kolejka zamówień</param>
    public static void ChangeOrderStatusById(OrderQueue queue)
    {
        queue.DisplayQueue();
        Console.WriteLine("Podaj numer zamówienia, którego status chcesz zmienić:");
        if (int.TryParse(Console.ReadLine(), out int orderId))
        {
            Order? orderToChange = queue.orders.FirstOrDefault(o => o.id == orderId);
            if (orderToChange != null)
            {
                Console.WriteLine("Wybierz nowy status zamówienia:");
                Console.WriteLine("1. zamówione");
                Console.WriteLine("2. zaakceptowane");
                Console.WriteLine("3. w przygotowaniu");
                Console.WriteLine("4. gotowe");
                Console.WriteLine("5. w dostawie");
                Console.WriteLine("6. dostarczone");
                Console.WriteLine("6. anulowane");
                int newStatusChoice = int.Parse(Console.ReadLine()!);
                switch (newStatusChoice)
                {
                    case 1:
                        orderToChange.UpdateStatus(OrderStatus.ORDERED);
                        break;
                    case 2:
                        orderToChange.UpdateStatus(OrderStatus.ACCEPTED);
                        break;
                    case 3:
                        orderToChange.UpdateStatus(OrderStatus.PREPARING);
                        break;
                    case 4:
                        orderToChange.UpdateStatus(OrderStatus.READY);
                        break;
                    case 5:
                        orderToChange.UpdateStatus(OrderStatus.InDELIVERY);
                        break;
                    case 6:
                        orderToChange.UpdateStatus(OrderStatus.DELIVERED);
                        break;
                    case 7:
                        orderToChange.UpdateStatus(OrderStatus.CANCELLED);
                        break;
                    default:
                        Console.WriteLine("Nieprawidłowy wybór statusu.");
                        return;
                }
                Console.WriteLine("Status zamówienia został zaktualizowany.");
            }
            else
            {
                Console.WriteLine("Nie znaleziono zamówienia o podanym numerze.");
            }
        }
        else
        {
            Console.WriteLine("Niepoprawny format numeru zamówienia.");
        }
    }
    /// <summary>
    /// Dodaje pizzę do menu, pracownik nadaje nazwę, rozmiar i składniki pizzy.
    /// </summary>
    /// <param name="menu">Menu pizzy</param>
    public static void AddPizzaToMenu(Menu menu)
    {
        Console.WriteLine("=== TWORZENIE PIZZY ===");
        Console.WriteLine("Podaj nazwę pizzy:");
        string pizzaName = Console.ReadLine()!;
        Console.WriteLine("Podaj rozmiar pizzy \n 1. mała \n 2. średnia \n 3. duża");
        int choice = int.Parse(Console.ReadLine()!);
        PizzaSize size = PizzaSize.SMALL;
        if (choice < 1 || choice > 3)
        {
            Console.WriteLine("Nieprawidłowy wybór. Spróbuj ponownie.");
            CreateCustomPizza();
        }
        else
        {
            if (choice == 1)
            {
                size = PizzaSize.SMALL;
            }
            else if (choice == 2)
            {
                size = PizzaSize.MEDIUM;
            }
            else
            {
                size = PizzaSize.LARGE;

            }
        }
        Console.WriteLine("Wybierz składniki:");
        List<Ingredient> ingredients = new();
        while (true)
        {
            int ingredientId = 1;
            foreach (var ingredient in Ingredient.allIngredients)
            {
                Console.WriteLine($"{ingredientId}. {ingredient.Name} - {ingredient.Price} zł");
                ingredientId++;
            }
            Console.WriteLine("Wybierz składnik (lub wpisz 0, aby zakończyć):");
            int ingredientChoice = int.Parse(Console.ReadLine()!);
            if (ingredientChoice == 0)
            {
                break; // Zakończ wybieranie składników
            }
            if (ingredientChoice < 1 || ingredientChoice > Ingredient.allIngredients.Count)
            {
                Console.WriteLine("Nieprawidłowy wybór. Spróbuj ponownie.");
                continue; // Poproś o ponowny wybór składnika
            }
            ingredients.Add(Ingredient.allIngredients[ingredientChoice - 1]); // Dodaj składnik do listy
        }

        Pizza customPizza = new Pizza(pizzaName, ingredients, size, false);
        // Logika dodawania pizzy do menu
        Console.WriteLine($"Stworzono pizzę: {customPizza.name}, rozmiar: {customPizza.size}, skład: {string.Join(", ", customPizza.ingredients.Select(i => i.Name))}");
        menu.AddPizza(customPizza);

    }
    /// <summary>
    /// Tworzy składnik, pracownik nadaje nazwę i cenę składnika.
    /// </summary>
    public static void CreateIngredient()
    {
        Console.WriteLine("=== TWORZENIE SKŁADNIKA ===");
        Console.WriteLine("Podaj nazwę składnika:");
        string ingredientName = Console.ReadLine()!;
        Console.WriteLine("Podaj cenę składnika (x , x): ");
        double ingredientPrice = double.Parse(Console.ReadLine()!);
        Ingredient newIngredient = new Ingredient(ingredientName, ingredientPrice);
        Console.WriteLine($"Stworzono składnik: {newIngredient.Name}, cena: {newIngredient.Price} zł");
    }
}
