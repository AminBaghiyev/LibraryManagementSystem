using LibraryManagementSystem.Models;

namespace LibraryManagementSystem;

internal class Program
{
    static void Main(string[] args)
    {
        App app = new();
        App.WarningMessage("Welcome to the Library Management System!");
        string input = "";

        while (true)
        {
            App.CommandSection();
            input = Console.ReadLine();
            Console.Clear();

            switch (input)
            {
                case "1":
                    app.GetLibrarianByIdPage();
                    break;

                case "2":
                    app.GetAllLibrariansPage();
                    break;

                case "3":
                    app.AddLibrarianPage();
                    break;

                case "4":
                    app.DeleteLibrarianPage();
                    break;

                case "0":
                    return;

                default:
                    App.ErrorMessage("There is no such command!");
                    break;
            }
        }
    }
}
