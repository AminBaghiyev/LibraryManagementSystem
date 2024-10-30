namespace LibraryManagementSystem.Models;

internal sealed class LibraryMember : Person
{
    public DateTime MembershipDate { get; set; }

    public LibraryMember(string Name) : base(Name)
    {
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"Member Id: {Id}");
        Console.WriteLine($"Member name: {Name}");
        Console.WriteLine($"Member membership date: {MembershipDate}");
        Console.WriteLine($"Removed: {IsSoftDelete}");
    }
}
