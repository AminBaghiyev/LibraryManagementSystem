using LibraryManagementSystem.Enums;
using LibraryManagementSystem.Services.Concretes;

namespace LibraryManagementSystem.Models;

internal class App
{
    private LibrarianService _librarianService;
    private LibraryMemberService _memberService;
    private BookService _bookService;

    public App()
    {
        _librarianService = new LibrarianService();
        _memberService = new LibraryMemberService();
        _bookService = new BookService();
    }

    #region Components
    public static void CommandSection()
    {
        HeaderMessage("Librarian commands");
        Console.WriteLine("1 -> Get librarian by id");
        Console.WriteLine("2 -> Get all librarians");
        Console.WriteLine("3 -> Add librarian");
        Console.WriteLine("4 -> Delete librarian");

        HeaderMessage("Member commands");
        Console.WriteLine("5 -> Get library member by id");
        Console.WriteLine("6 -> Get all library members");
        Console.WriteLine("7 -> Add library member");
        Console.WriteLine("8 -> Delete library member");

        HeaderMessage("Book commands");
        Console.WriteLine("9 -> Get book by id");
        Console.WriteLine("10 -> Get all books");
        Console.WriteLine("11 -> Add a book");
        Console.WriteLine("12 -> Delete a book");

        Console.WriteLine();
        ErrorMessage("0 -> Quit");
        Console.WriteLine();
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

    public static void SearchFooterSection(Action page)
    {
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
                page();
                break;

            case "0":
                Environment.Exit(0);
                break;
        }
    }

    #region Book Components
    public void AddBookPage()
    {
        HeaderMessage("Book Adding Page");

        Console.Write("Enter book's title: ");
        string bookTitle = Console.ReadLine();

        Console.Write("Enter book's publication date (format: \"dd.MM.yyyy\"): ");
        DateTime.TryParse(Console.ReadLine(), out DateTime bookPublicationYear);

        Book book = new(bookTitle, bookPublicationYear);

        Console.Write("Enter book's genre (Fiction, NonFiction, Science, Art): ");
        Enum.TryParse(Console.ReadLine(), true, out BookGenre bookGenre);
        book.Genre = bookGenre;

        _bookService.AddBook(book);

        Console.Clear();
        SuccessMessage("Book added successfully!\n");
    }

    public void GetAllBooksPage()
    {
        HeaderMessage("All Books");

        foreach (var book in _bookService.GetAllBooks())
        {
            Console.WriteLine();
            book.DisplayInfo();
        }

        FooterSection();
    }

    public void GetBookByIdPage()
    {
        HeaderMessage("Search Book By Id Page");

        bool isFound = false;
        Console.Write("Enter book's id: ");
        int.TryParse(Console.ReadLine(), out int id);

        foreach (Book book in _bookService.GetAllBooks())
        {
            if (book.Id == id)
            {
                Console.WriteLine();
                book.DisplayInfo();
                isFound = true;
            }
        }

        if (!isFound) ErrorMessage("Book not found!");

        SearchFooterSection(GetBookByIdPage);
    }

    public void DeleteBookPage()
    {
        HeaderMessage("Delete Book");

        bool isFound = false;
        Console.Write("Enter book's id: ");
        int.TryParse(Console.ReadLine(), out int id);

        bool isSoftDelete = true;
        Console.Write("Soft delete (true or false): ");
        bool.TryParse(Console.ReadLine(), out isSoftDelete);

        foreach (Book book in _bookService.GetAllBooks())
        {
            if (book.Id == id)
            {
                _bookService.DeleteBook(id, isSoftDelete);
                isFound = true;
            }
        }

        if (!isFound) ErrorMessage("Book not found!");
        else SuccessMessage($"Book {(isSoftDelete ? "soft" : "hard")} deleted successfully.");

        FooterSection();
    }
    #endregion

    #region LibraryMember Components
    public void AddLibraryMemberPage()
    {
        HeaderMessage("Member Adding Page");

        Console.Write("Enter member's name: ");
        LibraryMember member = new(Console.ReadLine());

        Console.Write("Enter member's membership date (format: \"dd.MM.yyyy\"): ");
        DateTime.TryParse(Console.ReadLine(), out DateTime membershipDate);
        member.MembershipDate = membershipDate;

        _memberService.CreateLibraryMember(member);

        Console.Clear();
        SuccessMessage("Member added successfully!\n");
    }

    public void GetAllLibraryMembersPage()
    {
        HeaderMessage("All Library Members");

        foreach (var member in _memberService.GetAllLibraryMembers())
        {
            Console.WriteLine();
            member.DisplayInfo();
        }

        FooterSection();
    }

    public void GetLibraryMemberByIdPage()
    {
        HeaderMessage("Search Member By Id Page");

        bool isFound = false;
        Console.Write("Enter member's id: ");
        int.TryParse(Console.ReadLine(), out int id);

        foreach (LibraryMember member in _memberService.GetAllLibraryMembers())
        {
            if (member.Id == id)
            {
                Console.WriteLine();
                member.DisplayInfo();
                isFound = true;
            }
        }

        if (!isFound) ErrorMessage("Member not found!");

        SearchFooterSection(GetLibraryMemberByIdPage);
    }

    public void DeleteLibraryMemberPage()
    {
        HeaderMessage("Delete Member");

        bool isFound = false;
        Console.Write("Enter member's id: ");
        int.TryParse(Console.ReadLine(), out int id);

        bool isSoftDelete = true;
        Console.Write("Soft delete (true or false): ");
        bool.TryParse(Console.ReadLine(), out isSoftDelete);

        foreach (LibraryMember member in _memberService.GetAllLibraryMembers())
        {
            if (member.Id == id)
            {
                _memberService.DeleteLibraryMember(id, isSoftDelete);
                isFound = true;
            }
        }

        if (!isFound) ErrorMessage("Member not found!");
        else SuccessMessage($"Member {(isSoftDelete ? "soft" : "hard")} deleted successfully.");

        FooterSection();
    }
    #endregion

    #region Librarian Components
    public void AddLibrarianPage()
    {
        HeaderMessage("Librarian Adding Page");

        Console.Write("Enter librarian name: ");
        Librarian librarian = new(Console.ReadLine());

        Console.Write("Enter librarian hire date (format: \"dd.MM.yyyy\"): ");
        DateTime.TryParse(Console.ReadLine(), out DateTime hireDate);
        librarian.HireDate = hireDate;

        _librarianService.CreateLibrarian(librarian);

        Console.Clear();
        SuccessMessage("Librarian added successfully!\n");
    }

    public void GetAllLibrariansPage()
    {
        HeaderMessage("All Librarians");

        foreach (var librarian in _librarianService.GetAllLibrarians())
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

        foreach (Librarian librarian in _librarianService.GetAllLibrarians())
        {
            if (librarian.Id == id)
            {
                Console.WriteLine();
                librarian.DisplayInfo();
                isFound = true;
            }
        }

        if (!isFound) ErrorMessage("Librarian not found!");

        SearchFooterSection(GetLibrarianByIdPage);
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

        foreach (Librarian librarian in _librarianService.GetAllLibrarians())
        {
            if (librarian.Id == id)
            {
                _librarianService.DeleteLibrarian(id, isSoftDelete);
                isFound = true;
            }
        }

        if (!isFound) ErrorMessage("Librarian not found!");
        else SuccessMessage($"Librarian {(isSoftDelete ? "soft" : "hard")} deleted successfully.");

        FooterSection();
    }
    #endregion

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
