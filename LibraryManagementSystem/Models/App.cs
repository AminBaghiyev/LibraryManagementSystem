namespace LibraryManagementSystem.Models;

internal class App
{
    private LibrarianService _db;

    public App()
    {
        _db = new LibrarianService();
    }

    #region Components
    public static void CommandSection()
    {
        HeaderMessage("Application user manual");
        Console.WriteLine("1 -> Get librarian by id");
        Console.WriteLine("2 -> Get all librarians");
        Console.WriteLine("3 -> Add librarian");
        Console.WriteLine("4 -> Delete librarian");
        ErrorMessage("0 -> Quit");
        Console.WriteLine();
    }

    public void AddLibrarianPage()
    {
        HeaderMessage("Librarian Adding Page");

        Console.Write("Enter librarian name: ");
        Librarian librarian = new(Console.ReadLine());

        Console.Write("Enter librarian hire date (format: \"dd.MM.yyyy\"): ");
        DateTime.TryParse(Console.ReadLine(), out DateTime hireDate);
        librarian.HireDate = hireDate;

        _db.CreateLibrarian(librarian);

        Console.Clear();
        SuccessMessage("Librarian added successfully!\n");
    }

    public void GetAllLibrariansPage()
    {
        HeaderMessage("All Librarians");

        foreach (var librarian in _db.GetAllLibrarians())
        {
            Console.WriteLine();
            librarian.DisplayInfo();
        }

        FooterSection();
    }

    public void GetLibrarianByIdPage()
    {
        HeaderMessage("Search Librarian By Id Page");

        bool isFound = false;
        Console.Write("Enter librarian's id: ");
        int.TryParse(Console.ReadLine(), out int id);

        foreach (Librarian librarian in _db.GetAllLibrarians())
        {
            if (librarian.Id == id)
            {
                Console.WriteLine();
                librarian.DisplayInfo();
                isFound = true;
            }
        }

        if (!isFound) ErrorMessage("Librarian not found!");

        Console.WriteLine("\n1 -> To go to the home page");
        Console.WriteLine("2 -> To retry the search");
        ErrorMessage("0 -> Quit\n");
        string input = InfiniteInput(["1", "2", "0"], errorMessage: "Enter the right commands!");
        Console.Clear();

        switch (input)
        {
            case "1":
                return;
            case "2":
                GetLibrarianByIdPage();
                break;
            case "0":
                Environment.Exit(0);
                break;
        }
    }

    public void DeleteLibrarianPage()
    {
        HeaderMessage("Delete Librarian");

        bool isFound = false;
        Console.Write("Enter librarian's id: ");
        int.TryParse(Console.ReadLine(), out int id);

        bool isSoftDelete = true;
        Console.Write("Soft delete (true or false): ");
        bool.TryParse(Console.ReadLine(), out isSoftDelete);

        foreach (Librarian librarian in _db.GetAllLibrarians())
        {
            if (librarian.Id == id)
            {
                _db.DeleteLibrarian(id, isSoftDelete);
                isFound = true;
            }
        }

        if (!isFound) ErrorMessage("Librarian not found!");
        else SuccessMessage("Librarian deleted successfully.");

        FooterSection();
    }

    public static void FooterSection()
    {
        Console.WriteLine("\n1 -> To go to the home page");
        ErrorMessage("0 -> Quit\n");
        string input = InfiniteInput(["1", "0"], errorMessage: "Enter the right commands!");
        Console.Clear();

        switch (input)
        {
            case "1":
                return;

            case "0":
                Environment.Exit(0);
                break;
        }
    }
    #endregion

    #region Source Code
    public static string InfiniteInput(string[] expected, string message = "", string errorMessage = "", bool isUpper = false)
    {
        string input = "";
        while (true)
        {
            Console.Write(message);
            input = isUpper ?
                Console.ReadLine().Trim().ToUpper() :
                Console.ReadLine().Trim();
            if (expected.Contains(input)) { break; }
            if (errorMessage.Trim().Length > 0) { ErrorMessage(errorMessage); }
        }

        return input;
    }

    public static void HeaderMessage(string message)
    {
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine($"--- {message} ---");
        Console.ResetColor();
    }

    public static void ErrorMessage(string message)
    {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine(message);
        Console.ResetColor();
    }

    public static void SuccessMessage(string message)
    {
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine(message);
        Console.ResetColor();
    }

    public static void WarningMessage(string message)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(message);
        Console.ResetColor();
    }
    #endregion
}
