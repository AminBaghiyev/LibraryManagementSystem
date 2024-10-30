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

                case "5":
                    app.GetLibraryMemberByIdPage();
                    break;

                case "6":
                    app.GetAllLibraryMembersPage();
                    break;

                case "7":
                    app.AddLibraryMemberPage();
                    break;

                case "8":
                    app.DeleteLibraryMemberPage();
                    break;

                case "9":
                    app.GetBookByIdPage();
                    break;

                case "10":
                    app.GetAllBooksPage();
                    break;

                case "11":
                    app.AddBookPage();
                    break;

                case "12":
                    app.DeleteBookPage();
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
