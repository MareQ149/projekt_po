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
            return 3;
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
        Console.WriteLine("Podaj nazwę pizzy (wpisz '0' aby anulować akcję):");
        string pizzaName = Console.ReadLine()!;
        if (string.IsNullOrWhiteSpace(pizzaName) || pizzaName == "0")
        {
            Console.WriteLine("Anulowano tworzenie pizzy.");
            return null!;
        }
        Console.WriteLine("=== PODAJ ROZMIAR ===");
        Console.WriteLine("Podaj rozmiar pizzy \n1. Mała \n2. Średnia\n 3. Duża \n0. Anuluj");

        if (!int.TryParse(Console.ReadLine(), out int choice) || choice < 0 || choice > 3)
        {
            Console.WriteLine("Nieprawidłowy wybór. Spróbuj ponownie.");
            return CreateCustomPizza();
        }

        PizzaSize size;

        if (choice == 1)
        {
            size = PizzaSize.SMALL;
        }
        else if (choice == 2)
        {
            size = PizzaSize.MEDIUM;
        }
        else if (choice == 3)
        {
            size = PizzaSize.LARGE;
        }
        else
        {
            Console.WriteLine("Anulowano tworzenie pizzy.");
            return null!;
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

            string? input = Console.ReadLine();
            if (!int.TryParse(input, out int ingredientChoice))
            {
                Console.WriteLine("Nieprawidłowe dane. Wpisz numer składnika.");
                continue;
            }

            if (ingredientChoice == 0)
            {
                break;
            }

            if (ingredientChoice < 1 || ingredientChoice > Ingredient.allIngredients.Count)
            {
                Console.WriteLine("Nieprawidłowy wybór. Spróbuj ponownie.");
                continue;
            }

            ingredients.Add(Ingredient.allIngredients[ingredientChoice - 1]);
        }
        Pizza customPizza = new Pizza(pizzaName, ingredients, size, false);
        Console.WriteLine($"Stworzono pizzę: {customPizza.name}, rozmiar: {customPizza.size}, skład: {string.Join(", ", customPizza.ingredients.Select(i => i.Name))}");
        Console.WriteLine("Czy na pewno chcesz dodać tę pizzę do zamówienia? (tak/nie)");
        string? confirm = Console.ReadLine()?.ToLower();
        if (confirm != "tak")
        {
            Console.WriteLine("Anulowano dodawanie pizzy do zamówienia.");
            return null!;
        }
        else
        {
            Console.WriteLine("Pizza została dodana do zamówienia.");
            return customPizza;
        }
    }
    /// <summary>
    /// Tworzenie zamówienia, gdzie użytkownik może wybrać pizzę z menu lub stworzyć własną pizzę, a także zastosować promocję 2+1.
    /// </summary>
    /// <param name="menu">Menu pizzy</param>
    /// <param name="licznik">Id</param>
    /// <param name="queue">Kolejka zamówień</param>
    public static void CreateOrder(Menu menu, ref int licznik, OrderQueue queue)
    {
        
        Console.WriteLine("=== PROMOCJA ===");
        Console.WriteLine("Czy chcesz zastosować promocję 2+1? Tylko pizzę z menu!");
        Console.WriteLine("1. Tak");
        Console.WriteLine("2. Nie");
        Console.WriteLine("0. Anuluj zamówienie");
        string choice = Console.ReadLine()!;
        if (choice == "1")
        {
            Console.WriteLine("=== TWORZENIE ZAMÓWIENIA ===");
            Console.WriteLine("Wybierz 3 pizze, najtańsza będzie gratis!");
            menu.DisplayMenu();
            Console.WriteLine("Wybierz pierwszą pizzę:");
            string? input = Console.ReadLine();
            if (!int.TryParse(input, out int firstPizza) || firstPizza < 1 || firstPizza > menu.menu.Count)
            {
                Console.WriteLine("Nieprawidłowy wybór. Spróbuj ponownie.");
                CreateOrder(menu, ref licznik, queue);
                return;
            }
            Console.WriteLine("Wybierz drugą pizzę:");
            string? input2 = Console.ReadLine();
            if (!int.TryParse(input2, out int secondPizza) || secondPizza < 1 || secondPizza > menu.menu.Count)
            {
                Console.WriteLine("Nieprawidłowy wybór. Spróbuj ponownie.");
                CreateOrder(menu, ref licznik, queue);
                return;

            }
            Console.WriteLine("Wybierz trzecią pizzę:");
            string? input3 = Console.ReadLine();
            if (!int.TryParse(input3, out int thirdPizza) || thirdPizza < 1 || thirdPizza > menu.menu.Count)
            {
                Console.WriteLine("Nieprawidłowy wybór. Spróbuj ponownie.");
                CreateOrder(menu, ref licznik, queue);
                return;
            }
            List<Pizza> pizzas = new();
            pizzas.Add(menu.menu[firstPizza - 1]);
            pizzas.Add(menu.menu[secondPizza - 1]);
            pizzas.Add(menu.menu[thirdPizza - 1]);
            Console.WriteLine("Podaj nazwę zamówienia lub wpisz '0' aby anulować:");
            string orderName = Console.ReadLine()!;
            if (string.IsNullOrWhiteSpace(orderName) || pizzas.Count == 0)
            {
                Console.WriteLine("Błędne zamówienie!");
                CreateOrder(menu, ref licznik, queue);
                return;
            }
            else if (orderName == "0")
            {
                Console.WriteLine("Anulowano zamówienie.");
                return;
            }
            else
            {
                Order zamowienie = new Order(licznik, orderName, pizzas);
                licznik++;
                Promotion.ApplyPromo2Plus1(zamowienie);
                queue.AddToQueue(zamowienie);
            }
        }
        else if (choice == "2")
        {
            List<Pizza> pizzas = new();
            Console.WriteLine("=== TWORZENIE ZAMÓWIENIA ===");
            while (true)
            {
                Console.WriteLine("1. Wybierz pizzę z menu:");
                Console.WriteLine("2. Stwórz własną pizzę");
                Console.WriteLine("3. Zakończ zamówienie");
                Console.WriteLine("0. Anuluj zamówienie");
                string? input = Console.ReadLine();
                if (!int.TryParse(input, out int choice2))
                {
                    Console.WriteLine("Nieprawidłowe dane. Wpisz numer opcji.");
                    continue;
                }
                else if (choice2 == 1)
                {
                    menu.DisplayMenu();
                    Console.WriteLine("Wybierz pizzę:");
                    string? input2 = Console.ReadLine();
                    if (!int.TryParse(input2, out int pizzaChoice) || pizzaChoice < 1 || pizzaChoice > menu.menu.Count)
                    {
                        Console.WriteLine("Nieprawidłowe dane. Wpisz numer opcji.");
                        CreateOrder(menu, ref licznik, queue);
                        return;
                    }
                    Pizza wybranaPizza = menu.menu[pizzaChoice - 1];
                    pizzas.Add(wybranaPizza);
                }
                else if (choice2 == 2)
                {
                    pizzas.Add(CreateCustomPizza());
                }
                else if (choice2 == 3)
                {
                    Console.WriteLine("Podaj nazwę zamówienia:");
                    string orderName = Console.ReadLine()!;

                    if (string.IsNullOrWhiteSpace(orderName))
                    {
                        Console.WriteLine("Zamówienie musi posiadać nazwę! Zamówienie anulowane");
                        return;
                    }
                    else if (pizzas.Count == 0)
                    {
                        Console.WriteLine("Zamówienie musi zawierać przynajmniej jedną pizzę! Zamówienie anulowane");
                        return;
                    }
                    else
                    {
                        Order zamowienie = new Order(licznik, orderName, pizzas);
                        licznik++;
                        Promotion.ApplyPromo2Plus1(zamowienie);
                        queue.AddToQueue(zamowienie);
                        break;
                    }
                }
                else if (choice2 == 0)
                {
                    Console.WriteLine("Anulowano zamówienie.");
                    return;
                }
                else
                {
                    Console.WriteLine("Nieprawidłowy wybór. Spróbuj ponownie.");
                }
            }
        }
        else if (choice == "0")
        {
            Console.WriteLine("Anulowano zamówienie.");
            return;
        }
        else
        {
            Console.WriteLine("Nieprawidłowy wybór. Spróbuj ponownie.");
            CreateOrder(menu, ref licznik, queue);
            return;
        }
    }
    /// <summary>
    /// Wyświetla aktualne zamówienia w kolejce.
    /// </summary>
    /// <param name="queue">Kolejka zamówień</param>
    public static void ViewCurrentOrders(OrderQueue queue)
    {
        Console.WriteLine("=== ZAMÓWIENIA ===");
        queue.DisplayQueue();
    }
    /// <summary>
    /// Anuluje zamówienie na podstawie jego ID.
    /// </summary>
    /// <param name="queue">Kolejka zamówień</param>
    public static void CancelOrderById(OrderQueue queue)
    {
        if (queue.orders.Count == 0)
        {
            Console.WriteLine("Brak zamówień do anulowania.");
            return;
        }
        Console.WriteLine("=== ANULOWANIE ZAMÓWIENIA ===");
        queue.DisplayQueue();
        Console.WriteLine("Podaj numer zamówienia do anulowania (Wpisz 0 aby anulować akcję):");

        if (int.TryParse(Console.ReadLine(), out int anulowaneZamowienie))
        {
            Order? orderToCancel = queue.orders.FirstOrDefault(o => o.id == anulowaneZamowienie);

            if (orderToCancel != null)
            {
                orderToCancel.CancelOrder();
                Console.WriteLine("Zamówienie zostało anulowane.");
            }
            else if (anulowaneZamowienie == 0)
            {
                Console.WriteLine("Anulowano akcję anulowania zamówienia.");
                return;
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
        Console.WriteLine("=== ZMIANA STATUSU ZAMÓWIENIA ===");
        if (queue.orders.Count == 0)
        {
            Console.WriteLine("Brak zamówień do aktualizowania.");
            return;
        }
        queue.DisplayQueue();
        Console.WriteLine("Podaj numer zamówienia, którego status chcesz zmienić (wpisz '0' aby anulować akcję):");
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
                Console.WriteLine("7. anulowane");
                string? input = Console.ReadLine();
                if (!int.TryParse(input, out int newStatusChoice))
                {
                    Console.WriteLine("Nieprawidłowe dane. Wpisz numer statusu.");
                    return;
                }
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
            else if (orderId == 0)
            {
                Console.WriteLine("Anulowano akcję zmiany statusu zamówienia.");
                return;
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
        Console.WriteLine("Podaj nazwę pizzy (wpisz '0' aby anulować akcję):");
        string pizzaName = Console.ReadLine()!;
        if (string.IsNullOrWhiteSpace(pizzaName) || pizzaName == "0")
        {
            Console.WriteLine("Anulowano tworzenie pizzy.");
            return;
        }
        Console.WriteLine("Podaj rozmiar pizzy \n1. Mała \n2. Średnia \n3. Duża \n4. Anuluj akcję");
        string? input = Console.ReadLine();
        if (!int.TryParse(input, out int choice))
        {
            Console.WriteLine("Nieprawidłowe dane.");
            return;
        }
        PizzaSize size = PizzaSize.SMALL;
        if (choice < 1 || choice > 4)
        {
            Console.WriteLine("Nieprawidłowy wybór. Spróbuj ponownie.");
            AddPizzaToMenu(menu);
            return;
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
            else if (choice == 3)
            {
                size = PizzaSize.LARGE;

            }
            else if (choice == 4)
            {
                Console.WriteLine("Anulowano tworzenie pizzy.");
                return;
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
            string? input2 = Console.ReadLine();

            if (!int.TryParse(input2, out int ingredientChoice))
            {
                Console.WriteLine("Nieprawidłowe dane. Wpisz numer składnika.");
                continue;
            }
            if (ingredientChoice == 0)
            {
                break;
            }
            if (ingredientChoice < 1 || ingredientChoice > Ingredient.allIngredients.Count)
            {
                Console.WriteLine("Nieprawidłowy wybór. Spróbuj ponownie.");
                continue;
            }
            ingredients.Add(Ingredient.allIngredients[ingredientChoice - 1]);
        }

        Pizza customPizza = new Pizza(pizzaName, ingredients, size, false);
        Console.WriteLine($"Stworzono pizzę: {customPizza.name}, rozmiar: {customPizza.size}, skład: {string.Join(", ", customPizza.ingredients.Select(i => i.Name))}");
        Console.WriteLine("Czy na pewno chcesz dodać tę pizzę do menu? (Tak/Nie)");
        string? confirm = Console.ReadLine()?.ToLower();
        if (confirm != "tak")
        {
            Console.WriteLine("Anulowano dodawanie pizzy do menu.");
            return;
        }
        else
        {
            Console.WriteLine("Pizza została dodana do menu.");
            menu.AddPizza(customPizza);
        }
    }
    /// <summary>
    /// Tworzy składnik, pracownik nadaje nazwę i cenę składnika.
    /// </summary>
    public static void CreateIngredient()
    {
        Console.WriteLine("=== TWORZENIE SKŁADNIKA ===");
        string ingredientName = "";
        while (string.IsNullOrWhiteSpace(ingredientName))
        {
            Console.WriteLine("Podaj nazwę składnika (Wpisz '0' aby anulować):");
            ingredientName = Console.ReadLine()!;

            if (string.IsNullOrWhiteSpace(ingredientName))
            {
                Console.WriteLine("Nazwa nie może być pusta. Spróbuj ponownie.");
            }
            else if (ingredientName == "0")
            {
                Console.WriteLine("Anulowano tworzenie składnika.");
                return;
            }
            else if (Ingredient.allIngredients.Any(i => i.Name.Equals(ingredientName, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine("Składnik o tej nazwie już istnieje. Wprowadź inną nazwę.");
                ingredientName = "";
            }
        }
        double ingredientPrice;
        Console.Write("Podaj cenę składnika (wpisz '0' aby anulować akcję): ");
        string input = Console.ReadLine()!;
        if (input == "0")
        {
            Console.WriteLine("Anulowano tworzenie składnika.");
            return;
        }
        while (!double.TryParse(input, out ingredientPrice))
        {
            Console.WriteLine("Nieprawidłowy format. Wprowadź liczbę (np. 4,99): ");
            input = Console.ReadLine()!;
        }
        Console.WriteLine($"Cena składnika: {ingredientPrice} zł");
        Ingredient newIngredient = new Ingredient(ingredientName, ingredientPrice);
        Console.WriteLine($"Stworzono składnik: {newIngredient.Name}, cena: {newIngredient.Price} zł");
    }
}
