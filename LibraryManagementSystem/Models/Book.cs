using LibraryManagementSystem.Enums;

namespace LibraryManagementSystem.Models;

internal class Book : LibraryItem
{
    public BookGenre Genre { get; set; }

    public Book(string Title, DateTime? PublicationYear) : base(Title, PublicationYear)
    {
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"Title: {Title}");
        Console.WriteLine($"Genre: {Genre}");
        Console.WriteLine($"Publication year: {PublicationYear}");
        Console.WriteLine($"Removed: {IsSoftDelete}");
    }
}
