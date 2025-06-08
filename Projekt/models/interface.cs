public class Interface {
    public void Select() 
    {
        Console.WriteLine("Wybierz rodzaj konta: 1 - Klient, 2 - Pracownik");
        string wybor = Console.ReadLine()!;
        if(wybor == "1")
        {

        }
    }
    public void UserInterface()
    {
        Console.WriteLine("=== MENU GŁÓWNE ===");
        Console.WriteLine("1. Zobacz menu pizzy");
        Console.WriteLine("2. Stwórz zamówienie");
        Console.WriteLine("3. Zobacz kolejkę zamówień");
        Console.WriteLine("5. Anuluj zamówienie");
        Console.WriteLine("0. Wyjście");
    }

    public void WorkerInterface()
    {
        Console.WriteLine("=== MENU PRACOWNIKA ===");
        Console.WriteLine("1. Zobacz menu pizzy");
        Console.WriteLine("2. Zobacz zamówienia");
        Console.WriteLine("3. Zobacz kolejkę zamówień");
        Console.WriteLine("4. Zmień status zamówienia (po nazwie)");
        Console.WriteLine("5. Usuń zamówienie (po nazwie)");
        Console.WriteLine("6. Dodaj pizze do menu");
        Console.WriteLine("7. Dodaj składnik do listy składników");
        Console.WriteLine("0. Wyjście");
    }
}
