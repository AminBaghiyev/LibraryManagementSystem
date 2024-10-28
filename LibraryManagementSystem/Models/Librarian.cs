namespace LibraryManagementSystem.Models;

internal class Librarian : Person
{
    public DateTime HireDate { get; set; }

    public bool IsSoftDelete { get; set; }
    public Librarian(string Name) : base(Name)
    {
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Librarian Id: {Id}");
        Console.WriteLine($"Librarian name: {Name}");
        Console.WriteLine($"Librarian hire date: {HireDate}");
        Console.WriteLine($"Removed: {IsSoftDelete}");
    }
}
